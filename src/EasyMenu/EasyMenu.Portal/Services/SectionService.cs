using EasyMenu.Core.Model;
using EasyMenu.Core.Model.Enums;
using EasyMenu.Portal.Models;
using EasyMenu.Portal.Models.Maps;
using EasyMenu.Portal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Portal.Services;

public class SectionService : ISectionService
{
    private readonly EasyMenuContext _context;

    public SectionService(EasyMenuContext context)
    {
        _context = context;
    }
    
    public async Task<SectionDto> CreateSection(SectionDto section)
    {
        var entity = section.Map();
        var entityEntry = _context.Sections.Add(entity);
        await _context.SaveChangesAsync();

        var sectionDb = await _context.Sections.FindAsync(entityEntry.Entity.SectionId);
        return sectionDb?.Map() ?? section;
    }

    public Task<bool> UpdateSection(SectionDto sectionDto)
    {
        throw new NotImplementedException();
    }

    public async Task<SectionDto> GetSection(int sectionId)
    {
        var section = await _context.Sections
            .Include(s => s.Products)
            .Where(s => s.SectionId == sectionId)
            .FirstOrDefaultAsync();
        var sectionDto = section is null
            ? new SectionDto()
            : section.Map();
        return sectionDto;
    }

    public async Task<IEnumerable<SectionDto>> GetAll(int tenantId)
    {
        var sections = await _context.Sections
            .Where(s => s.TenantId == tenantId)
            .ToArrayAsync();
        
        var sectionDtos = sections.Select(s => s.Map());
        return sectionDtos; 
    }

    public async Task<bool> DeleteSection(int sectionId)
    {
        var entity = await _context.Sections
            .FindAsync(sectionId);

        if (entity is null) return false;
        entity.Status = Status.Inactive;

        var result = await _context.SaveChangesAsync();
        return result >= 1;
    }
}