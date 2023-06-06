using EasyMenu.Portal.Models;

namespace EasyMenu.Portal.Services.Interfaces;

public interface ISectionService
{
    public Task<SectionDto> CreateSection(SectionDto section);
    public Task<bool> UpdateSection(SectionDto section);
    public Task<SectionDto> GetSection(int sectionId);
    public Task<IEnumerable<SectionDto>> GetAll(int tenantId);
    public Task<bool> DeleteSection(int sectionId);
}