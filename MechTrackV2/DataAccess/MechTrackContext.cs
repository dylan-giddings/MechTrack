using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MechTrackContext : DbContext
    {
        public MechTrackContext() : base("MechTrackV2")
        {

        }
        public DbSet<Ammunition> Ammunition { get; set; }
        public DbSet<CritSlot> CritSlots { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Force> Forces { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Mech> Mechs { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerNote> PlayerNotes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<WarMachine> WarMachines { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}
