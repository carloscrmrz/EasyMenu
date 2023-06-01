´╗┐using EasyMenu.Core.Model.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Domains.Seeds;

public static class SectionSeeder
{
    private static readonly ICollection<Section> Sections = new Section[]
    {
        new() { SectionId = 1, SectionName = "Entradas", ImageUrl = "", StatusId = Status.Active },
        new() { SectionId = 2, SectionName = "Platos Fuertes", ImageUrl = "", StatusId = Status.Active },
        new() { SectionId = 3, SectionName = "Bebidas", ImageUrl = "", StatusId = Status.Active },
        new() { SectionId = 4, SectionName = "Postres", ImageUrl = "", StatusId = Status.Active }
    };
    
    public static void SeedSections(this EntityTypeBuilder<Section> builder)
    {
        builder.HasData(Sections);
    }
}