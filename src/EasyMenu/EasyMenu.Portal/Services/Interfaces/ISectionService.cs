using EasyMenu.Portal.Models;

namespace EasyMenu.Portal.Services.Interfaces;

public interface ISectionService
{
    public Task<SectionDto> CreateSection(SectionDto sectionDto);
    public Task<SectionDto> UpdateSection(SectionDto sectionDto);
    public Task<SectionDto> GetSection(int sectionId);
    public Task<bool> DeleteSection(int sectionId);
}