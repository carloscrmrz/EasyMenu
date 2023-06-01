´╗┐using EasyMenu.Core.Model.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Domains.Seeds;

public static class SuscriptionSeeder
{
    private static readonly ICollection<Suscription> Suscriptions = new Suscription[]
    {
        new() { SuscriptionId = 1, SuscriptionType = Enums.Suscriptions.Free, Price = 0, Discout = 0, Status = Status.Active },
        new() { SuscriptionId = 2, SuscriptionType = Enums.Suscriptions.PaidOneRest, Price = 10, Discout = 0, Status = Status.Active },
        new() { SuscriptionId = 3, SuscriptionType = Enums.Suscriptions.PaidSmallChain, Price = 100, Discout = 0, Status = Status.Active },
        new() { SuscriptionId = 4, SuscriptionType = Enums.Suscriptions.PaidBigChain, Price = 1000, Discout = 0, Status = Status.Active },
    };

    public static void SeedSuscriptions(this EntityTypeBuilder<Suscription> builder)
    {
        builder.HasData(Suscriptions);
    }
}