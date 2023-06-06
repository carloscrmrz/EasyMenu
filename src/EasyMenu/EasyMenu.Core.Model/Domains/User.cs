using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Core.Model.Enums;
using EasyMenu.Core.Utils;

namespace EasyMenu.Core.Model.Domains;

public class User : BaseEntity
{
    public User()
    {
        Status = Status.Active;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    public int TenantId { get; set; }

    [Required]
    [Column(TypeName = "VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS")]
    public string UserLogin { get; set; }

    [Required]
    [Column(TypeName = "VARCHAR(500) COLLATE SQL_Latin1_General_CP1_CI_AS")]
    public byte[] UserPass { get; private set; }

    [Required]
    [Column(TypeName = "VARCHAR(500) COLLATE SQL_Latin1_General_CP1_CI_AS")]
    public byte[] UserSalt { get; private set; }

    public DateTime? DateOfLastPasswordChange { get; set; }
    public bool IsDisabledByInactivity { get; set; }
    public bool Locked { get; set; }
    public bool TemporaryLocked { get; set; }
    public int AccessFailedCount { get; set; }
    public Status Status { get; set; }
    
    public DateTimeOffset? ExpirationDate { get; set; }

    public virtual Tenant Tenant { get; set; }

    public void SetNewUserPass(string psw)
    {
        if (string.IsNullOrEmpty(psw)) return;
        CryptographyHelper.CreatePasswordHash(psw, out var passwordHash, out var passwordSalt);
        UserPass = passwordHash;
        UserSalt = passwordSalt;
    }

    public bool VerifyPasswordHash(string password)
    {
        return CryptographyHelper.VerifyPasswordHash(password, UserPass, UserSalt);
    }
}