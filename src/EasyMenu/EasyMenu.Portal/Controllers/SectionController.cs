using EasyMenu.Portal.Models;
using EasyMenu.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.Portal.Controllers;

[ApiController]
[Route("[controller]")]
public class SectionController : ControllerBase
{
    private readonly ISectionService _sectionService;

    public SectionController(ISectionService sectionService)
    {
        _sectionService = sectionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sections = await _sectionService.GetAll(1);
        return Ok(sections);
    }

    [HttpGet("{sectionId:int}")]
    public async Task<IActionResult> GetSection(int sectionId)
    {
        var section = await _sectionService.GetSection(sectionId);
        return Ok(section);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSection(SectionDto sectionDto)
    {
        var section = await _sectionService.CreateSection(sectionDto);
        return Ok(section);
    }

    // [HttpPut]
    // public async Task<IActionResult> UpdateSection(SectionDto sectionDto)
    // {
    //     var result = await _sectionService.UpdateSection(sectionDto);
    //     return result ? Ok() : BadRequest();
    // }

    [HttpDelete("{sectionId:int}")]
    public async Task<IActionResult> DeleteSection(int sectionId)
    {
        var result = await _sectionService.DeleteSection(sectionId);
        return result ? Ok() : BadRequest();
    }
    
    [HttpPost("{sectionId:int}/product/{productId:int}")]
    public async Task<IActionResult> AddSectionToMenu(int productId, int sectionId)
    {
        var result = await _sectionService.AddSectionToMenu(productId, sectionId);
        return result ? Ok() : StatusCode(500);
    }
    
    [HttpPut("{sectionId:int}/product/{productId:int}")]
    public async Task<IActionResult> DeleteSectionFromMenu(int productId, int sectionId)
    {
        var result = await _sectionService.DeleteSectionFromMenu(productId, sectionId);
        return result ? Ok() : StatusCode(500);
    }
}