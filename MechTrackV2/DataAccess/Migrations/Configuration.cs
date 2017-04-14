namespace Models.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.MechTrackContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.MechTrackContext context)
        {
            context.Players.AddOrUpdate(p => p.Name,
                new Player { Name = "Corey" },
                new Player { Name = "Dylan" });

            context.Forces.AddOrUpdate(f => f.Name,
                new Force { Name = "Hammer Lance", PlayerID = 1, ForceType = ForceType.Lance },
                new Force { Name = "Anvil Lance", PlayerID = 2, ForceType = ForceType.Lance });

            context.Mechs.AddOrUpdate(m => m.Name,
                new Mech { Name = "Zues", Tonnage = 80, Locations = new List<Location> { new Location { LocationType = LocationType.LeftArmArmor, CurrentValue = 2, MaxValue = 2 } }, Type = "ZEU" });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
