using EasyMenu.Core.Model.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Domains.Seeds;

public static class SectionSeeder
{
    private static readonly ICollection<Section> Sections = new Section[]
    {
        new() { SectionId = 1, TenantId = 1, SectionName = "Entradas", ImageUrl = "", Status = Status.Active },
        new() { SectionId = 2, TenantId = 1, SectionName = "Platos Fuertes", ImageUrl = "", Status = Status.Active },
        new() { SectionId = 3, TenantId = 1, SectionName = "Bebidas", ImageUrl = "", Status = Status.Active },
        new() { SectionId = 4, TenantId = 1, SectionName = "Postres", ImageUrl = "", Status = Status.Active }
    };
    
    public static void SeedSections(this EntityTypeBuilder<Section> builder)
    {
        builder.HasData(Sections);
    }
}