namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyInitialRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Forces", "Player_PlayerID", "dbo.Players");
            DropIndex("dbo.Forces", new[] { "Player_PlayerID" });
            RenameColumn(table: "dbo.Forces", name: "Player_PlayerID", newName: "PlayerID");
            AddColumn("dbo.Equipment", "EquipmentNotes", c => c.String());
            AddColumn("dbo.Crew", "DrivingSkill", c => c.Int());
            AddColumn("dbo.Crew", "GunnerySkill", c => c.Int());
            AddColumn("dbo.Crew", "Discriminator", c => c.String(maxLength: 128));
            AddColumn("dbo.MechWarriors", "GunnerySkill", c => c.Int(nullable: false));
            AddColumn("dbo.MechWarriors", "PilotingSkill", c => c.Int(nullable: false));
            AddColumn("dbo.Forces", "ParentForceID", c => c.Int(nullable: false));
            AddColumn("dbo.Forces", "ParentForce_ForceID", c => c.Int());
            AddColumn("dbo.WarMachines", "WarMachineNotes", c => c.String());
            AddColumn("dbo.Vehicles", "Crew_CrewID", c => c.Int());
            AlterColumn("dbo.Forces", "PlayerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Forces", "PlayerID");
            CreateIndex("dbo.Forces", "ParentForce_ForceID");
            CreateIndex("dbo.PlayerNotes", "PlayerID");
            CreateIndex("dbo.Vehicles", "Crew_CrewID");
            AddForeignKey("dbo.Forces", "ParentForce_ForceID", "dbo.Forces", "ForceID");
            AddForeignKey("dbo.PlayerNotes", "PlayerID", "dbo.Players", "PlayerID", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "Crew_CrewID", "dbo.Crew", "CrewID");
            AddForeignKey("dbo.Forces", "PlayerID", "dbo.Players", "PlayerID", cascadeDelete: true);
            DropColumn("dbo.Ammunition", "AmmunitionID");
            DropColumn("dbo.Equipment", "EquipmentID");
            DropColumn("dbo.Weapons", "WeaponID");
            DropColumn("dbo.MechWarriors", "MechWarriorID");
            DropColumn("dbo.MechWarriors", "Gunnery");
            DropColumn("dbo.MechWarriors", "Piloting");
            DropColumn("dbo.WarMachines", "WarMachineID");
            DropColumn("dbo.Mechs", "MechID");
            DropColumn("dbo.Vehicles", "VehicleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "VehicleID", c => c.Int(nullable: false));
            AddColumn("dbo.Mechs", "MechID", c => c.Int(nullable: false));
            AddColumn("dbo.WarMachines", "WarMachineID", c => c.Int(nullable: false));
            AddColumn("dbo.MechWarriors", "Piloting", c => c.Int(nullable: false));
            AddColumn("dbo.MechWarriors", "Gunnery", c => c.Int(nullable: false));
            AddColumn("dbo.MechWarriors", "MechWarriorID", c => c.Int(nullable: false));
            AddColumn("dbo.Weapons", "WeaponID", c => c.Int(nullable: false));
            AddColumn("dbo.Equipment", "EquipmentID", c => c.Int(nullable: false));
            AddColumn("dbo.Ammunition", "AmmunitionID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Forces", "PlayerID", "dbo.Players");
            DropForeignKey("dbo.Vehicles", "Crew_CrewID", "dbo.Crew");
            DropForeignKey("dbo.PlayerNotes", "PlayerID", "dbo.Players");
            DropForeignKey("dbo.Forces", "ParentForce_ForceID", "dbo.Forces");
            DropIndex("dbo.Vehicles", new[] { "Crew_CrewID" });
            DropIndex("dbo.PlayerNotes", new[] { "PlayerID" });
            DropIndex("dbo.Forces", new[] { "ParentForce_ForceID" });
            DropIndex("dbo.Forces", new[] { "PlayerID" });
            AlterColumn("dbo.Forces", "PlayerID", c => c.Int());
            DropColumn("dbo.Vehicles", "Crew_CrewID");
            DropColumn("dbo.WarMachines", "WarMachineNotes");
            DropColumn("dbo.Forces", "ParentForce_ForceID");
            DropColumn("dbo.Forces", "ParentForceID");
            DropColumn("dbo.MechWarriors", "PilotingSkill");
            DropColumn("dbo.MechWarriors", "GunnerySkill");
            DropColumn("dbo.Crew", "Discriminator");
            DropColumn("dbo.Crew", "GunnerySkill");
            DropColumn("dbo.Crew", "DrivingSkill");
            DropColumn("dbo.Equipment", "EquipmentNotes");
            RenameColumn(table: "dbo.Forces", name: "PlayerID", newName: "Player_PlayerID");
            CreateIndex("dbo.Forces", "Player_PlayerID");
            AddForeignKey("dbo.Forces", "Player_PlayerID", "dbo.Players", "PlayerID");
        }
    }
}
