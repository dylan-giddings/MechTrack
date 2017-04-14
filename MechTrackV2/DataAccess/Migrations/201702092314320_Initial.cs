namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Notes = c.String(),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateTable(
                "dbo.Crew",
                c => new
                    {
                        CrewID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CrewID);
            
            CreateTable(
                "dbo.CritSlots",
                c => new
                    {
                        CritSlotID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        CritSlotItemID = c.Int(),
                    })
                .PrimaryKey(t => t.CritSlotID)
                .ForeignKey("dbo.CritSlotItems", t => t.CritSlotItemID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID)
                .Index(t => t.CritSlotItemID);
            
            CreateTable(
                "dbo.CritSlotItems",
                c => new
                    {
                        CritSlotItemID = c.Int(nullable: false, identity: true),
                        ItemID = c.Int(nullable: false),
                        MaxQuantity = c.Int(nullable: false),
                        CurrentQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CritSlotItemID)
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.Forces",
                c => new
                    {
                        ForceID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ForceType = c.Int(nullable: false),
                        Player_PlayerID = c.Int(),
                    })
                .PrimaryKey(t => t.ForceID)
                .ForeignKey("dbo.Players", t => t.Player_PlayerID)
                .Index(t => t.Player_PlayerID);
            
            CreateTable(
                "dbo.Machines",
                c => new
                    {
                        MachineID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Tonnage = c.Int(nullable: false),
                        ForceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MachineID)
                .ForeignKey("dbo.Forces", t => t.ForceID, cascadeDelete: true)
                .Index(t => t.ForceID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        MaxValue = c.Int(nullable: false),
                        CurrentValue = c.Int(nullable: false),
                        MachineID = c.Int(nullable: false),
                        LocationType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID)
                .ForeignKey("dbo.Machines", t => t.MachineID, cascadeDelete: true)
                .Index(t => t.MachineID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PlayerID);
            
            CreateTable(
                "dbo.PlayerNotes",
                c => new
                    {
                        PlayerNoteID = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        PlayerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerNoteID);
            
            CreateTable(
                "dbo.Ammunition",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        AmmunitionID = c.Int(nullable: false),
                        AmmoType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Items", t => t.ItemID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        EquipmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Items", t => t.ItemID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.WarMachines",
                c => new
                    {
                        MachineID = c.Int(nullable: false),
                        WarMachineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MachineID)
                .ForeignKey("dbo.Machines", t => t.MachineID)
                .Index(t => t.MachineID);
            
            CreateTable(
                "dbo.Mechs",
                c => new
                    {
                        MachineID = c.Int(nullable: false),
                        MechWarrior_CrewID = c.Int(),
                        MechID = c.Int(nullable: false),
                        MechWarriorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MachineID)
                .ForeignKey("dbo.WarMachines", t => t.MachineID)
                .ForeignKey("dbo.MechWarriors", t => t.MechWarrior_CrewID)
                .Index(t => t.MachineID)
                .Index(t => t.MechWarrior_CrewID);
            
            CreateTable(
                "dbo.MechWarriors",
                c => new
                    {
                        CrewID = c.Int(nullable: false),
                        MechWarriorID = c.Int(nullable: false),
                        Gunnery = c.Int(nullable: false),
                        Piloting = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CrewID)
                .ForeignKey("dbo.Crew", t => t.CrewID)
                .Index(t => t.CrewID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        MachineID = c.Int(nullable: false),
                        VehicleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MachineID)
                .ForeignKey("dbo.WarMachines", t => t.MachineID)
                .Index(t => t.MachineID);
            
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        WeaponID = c.Int(nullable: false),
                        StandardHeatGenerated = c.Int(nullable: false),
                        StandardDamageValue = c.Int(nullable: false),
                        AmmoType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Items", t => t.ItemID)
                .Index(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weapons", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Vehicles", "MachineID", "dbo.WarMachines");
            DropForeignKey("dbo.MechWarriors", "CrewID", "dbo.Crew");
            DropForeignKey("dbo.Mechs", "MechWarrior_CrewID", "dbo.MechWarriors");
            DropForeignKey("dbo.Mechs", "MachineID", "dbo.WarMachines");
            DropForeignKey("dbo.WarMachines", "MachineID", "dbo.Machines");
            DropForeignKey("dbo.Equipment", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Ammunition", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Forces", "Player_PlayerID", "dbo.Players");
            DropForeignKey("dbo.Machines", "ForceID", "dbo.Forces");
            DropForeignKey("dbo.Locations", "MachineID", "dbo.Machines");
            DropForeignKey("dbo.CritSlots", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.CritSlots", "CritSlotItemID", "dbo.CritSlotItems");
            DropForeignKey("dbo.CritSlotItems", "ItemID", "dbo.Items");
            DropIndex("dbo.Weapons", new[] { "ItemID" });
            DropIndex("dbo.Vehicles", new[] { "MachineID" });
            DropIndex("dbo.MechWarriors", new[] { "CrewID" });
            DropIndex("dbo.Mechs", new[] { "MechWarrior_CrewID" });
            DropIndex("dbo.Mechs", new[] { "MachineID" });
            DropIndex("dbo.WarMachines", new[] { "MachineID" });
            DropIndex("dbo.Equipment", new[] { "ItemID" });
            DropIndex("dbo.Ammunition", new[] { "ItemID" });
            DropIndex("dbo.Locations", new[] { "MachineID" });
            DropIndex("dbo.Machines", new[] { "ForceID" });
            DropIndex("dbo.Forces", new[] { "Player_PlayerID" });
            DropIndex("dbo.CritSlotItems", new[] { "ItemID" });
            DropIndex("dbo.CritSlots", new[] { "CritSlotItemID" });
            DropIndex("dbo.CritSlots", new[] { "LocationID" });
            DropTable("dbo.Weapons");
            DropTable("dbo.Vehicles");
            DropTable("dbo.MechWarriors");
            DropTable("dbo.Mechs");
            DropTable("dbo.WarMachines");
            DropTable("dbo.Equipment");
            DropTable("dbo.Ammunition");
            DropTable("dbo.PlayerNotes");
            DropTable("dbo.Players");
            DropTable("dbo.Locations");
            DropTable("dbo.Machines");
            DropTable("dbo.Forces");
            DropTable("dbo.CritSlotItems");
            DropTable("dbo.CritSlots");
            DropTable("dbo.Crew");
            DropTable("dbo.Items");
        }
    }
}
