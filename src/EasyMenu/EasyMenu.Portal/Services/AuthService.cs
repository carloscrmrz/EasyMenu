using System.Linq.Expressions;
using System.Security.Claims;
using EasyMenu.Core.Dtos;
using EasyMenu.Core.Model;
using EasyMenu.Core.Model.Domains;
using EasyMenu.Core.Model.Enums;
using EasyMenu.Core.Utils;
using EasyMenu.Portal.Models;
using EasyMenu.Portal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Portal.Services;

public class AuthService : IAuthService
{
    private readonly EasyMenuContext _context;
    private readonly IConfiguration _config;

    public AuthService(EasyMenuContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }
    
    public async Task<LoginResult<User>> Login(Credentials credentials)
    {
        Expression<Func<User, bool>> predicate = u => u.UserLogin == credentials.UserLogin;
        var user = await QueryableUser(predicate).FirstOrDefaultAsync();
            
        if (user == null) return LoginResult<User>.Failed;
        if (user.StatusId == Status.Inactive) return LoginResult<User>.Disabled;

        if (user.Locked)
        {
            return LoginResult<User>.LockedOut(new User {Locked = user.Locked, AccessFailedCount = user.AccessFailedCount});
        }

        if ( user.Tenant.Status != Status.Active)
        {
            await AddAttemptsFail(user.UserId, user.TenantId, user.AccessFailedCount);
            return LoginResult<User>.TenantDisabled();
        }

        var valid = user.VerifyPasswordHash(credentials.UserPass);

        if (!valid)
        {
            await AddAttemptsFail(user.UserId, user.TenantId, user.AccessFailedCount);
            return LoginResult<User>.Failed;
        }

        var needChangePassword = VerifyNeedChangePassword(user.DateOfLastPasswordChange, user.ExpirationDate);

        if (needChangePassword)
            return LoginResult<User>.NotAllowed(new User
            {
                UserId = user.UserId,
                TenantId = user.TenantId,
            });

        await CleanAttemptsUser(user.UserId);
        return LoginResult<User>.Success(user);
    }
    private IQueryable<User> QueryableUser(Expression<Func<User, bool>> predicate)
    {
        var queryable = _context.Users
            .Include(user => user.Tenant);
        return queryable.Where(predicate).AsNoTracking();
    }

    private async Task AddAttemptsFail(int? userId, int? tenantId, int? accessFailedCount)
    {
        const int maxAttempts = EasyMenuConstants.DefaultAttemptsLogin;
        if (userId == null) return;
        {
            var user = new User {UserId = (int) userId};
            accessFailedCount++;
            if (accessFailedCount >= maxAttempts)
            {
                user.Locked = true;
                _context.Entry(user).Property(u => u.Locked).IsModified = true;
            }
            user.AccessFailedCount = accessFailedCount ?? 0;
            _context.Entry(user).Property(u => u.AccessFailedCount).IsModified = true;

            await _context.SaveChangesAsync();
            _context.Entry(user).State = EntityState.Detached;
        }
    }
    
    private async Task CleanAttemptsUser(int? userId)
    {
        if (userId == null) return;
        {
            var user = new User {UserId = (int) userId, AccessFailedCount = 0};
            _context.Entry(user).Property(u => u.AccessFailedCount).IsModified = true;
            await _context.SaveChangesAsync();
            _context.Entry(user).State = EntityState.Detached;
        }
    }
    
    private bool VerifyNeedChangePassword(DateTime? dateOfLastPasswordChange, DateTimeOffset? expirationDate)
    {
        if (dateOfLastPasswordChange is null) return true;
        if (expirationDate is null) return false;
        var dateDiff = (expirationDate - DateTimeOffset.Now).Value.TotalDays;
        return dateDiff <= 0;
    }
    
    public EasyMenuToken BuildToken(UserDto user, bool needChangePwd = false)
        {

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new(ClaimTypes.Name, user.UserLogin),
                new(ClaimTypes.GroupSid, user.TenantId.ToString()),
                new(ClaimTypes.Uri, user.Tenant.SubPath),
                new(ClaimTypes.Role, "Admin"),
                new(ClaimTypes.GivenName, user.Tenant?.TenantName ?? string.Empty),
            };

            var key = _config["Jwt:Key"];
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Issuer"];

            return new EasyMenuToken(key, issuer, audience, claims, EasyMenuConstants.TokenHoursValid);
        }
}