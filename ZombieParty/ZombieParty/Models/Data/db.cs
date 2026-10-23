using ZombieParty.Models;

namespace ZombieParty.Models.Data
{
    internal static class DB
    {
        internal static List<Zombie> Zombies { get; set; } = new List<Zombie>()
        {
            new Zombie(){Id=1,Force=20, Name= "LeChuck", Point=5, ZombieTypeId= 3,ShortDesc ="description"},
            new Zombie(){Id=2,Force=20, Name= "Lenore", Point=4, ZombieTypeId= 3,ShortDesc ="description"},
            new Zombie(){Id=3,Force=20, Name= "Draugr", Point=2, ZombieTypeId= 4,ShortDesc ="description"},
            new Zombie(){Id=4,Force=20, Name= "Ragamuffin", Point=5, ZombieTypeId= 4,ShortDesc ="description"},
            new Zombie(){Id=5,Force=20, Name= "Taxidermy", Point=1, ZombieTypeId= 4,ShortDesc ="description"},
            new Zombie(){Id=6,Force=20, Name= "chien de l'enfer", Point=7, ZombieTypeId= 3,ShortDesc ="description"},
            new Zombie(){Id=7,Force=20, Name= "Avogadro", Point=9, ZombieTypeId= 3,ShortDesc ="description"}
        };
        internal static List<ZombieType> ZombieTypes { get; set; } = new List<ZombieType>()
        {
            new ZombieType(){TypeName= "Virus", Id=1, Point=1},
            new ZombieType(){TypeName= "Contact", Id=2, Point=3},
            new ZombieType(){TypeName= "Fiction", Id=3, Point=3},
            new ZombieType(){TypeName= "Légendaire", Id=4, Point= 5}
        };

        internal static List<Weapon> Weapons { get; set; } = new List<Weapon>() {
            new Weapon(){Id=1, Name="Leopold", Description="This is to cut your friendly zombies", Force=200, Image="https://i.ibb.co/y5nCnXT/dagger-gfce31e967-1920.png", Lifespan=50, Price=421, Qty=21, QtyBought=3, Resistance=10, UpdatedDate=new DateTime(2012,1,1),   CreatedDate= new DateTime(1999,01,1)},
            new Weapon(){Id=2, Name="Master Shield", Description="An awesome Stainless Steel Shield", Force=10, Image="https://publicdomainvectors.org/photos/Shield-ClassicMedieval1.png", Lifespan=10, Price=500, Qty=30, QtyBought=1, Resistance=800, UpdatedDate=new DateTime(2012,1,1),   CreatedDate= new DateTime(1999,01,1)}
        };
    }
}
