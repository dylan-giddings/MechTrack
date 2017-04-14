namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCrews : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CombatVehicleCrew", "CrewID", "dbo.Crew");
            DropForeignKey("dbo.Mechs", "MechWarrior_CrewID", "dbo.MechWarriors");
            DropForeignKey("dbo.MechWarriors", "CrewID", "dbo.Crew");
            DropForeignKey("dbo.Vehicles", "Crew_CrewID", "dbo.CombatVehicleCrew");
            DropForeignKey("dbo.Machines", "Force_ForceID", "dbo.Forces");
            DropIndex("dbo.Forces", new[] { "ParentForce_ForceID" });
            DropIndex("dbo.Machines", new[] { "Force_ForceID" });
            DropIndex("dbo.CombatVehicleCrew", new[] { "CrewID" });
            DropIndex("dbo.Mechs", new[] { "MechWarrior_CrewID" });
            DropIndex("dbo.MechWarriors", new[] { "CrewID" });
            DropIndex("dbo.Vehicles", new[] { "Crew_CrewID" });
            DropColumn("dbo.Forces", "ParentForceID");
            RenameColumn(table: "dbo.Machines", name: "Force_ForceID", newName: "ForceID");
            RenameColumn(table: "dbo.Forces", name: "ParentForce_ForceID", newName: "ParentForceID");
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterID = c.Int(nullable: false),
                        Name = c.String(),
                        PilotingSkill = c.Int(nullable: false),
                        DrivingSkill = c.Int(nullable: false),
                        GunnerySkill = c.Int(nullable: false),
                        TotalExperience = c.Int(nullable: false),
                        UnspentExperience = c.Int(nullable: false),
                        MachineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterID)
                .ForeignKey("dbo.Machines", t => t.CharacterID)
                .Index(t => t.CharacterID);
            
            AddColumn("dbo.Machines", "CharacterID", c => c.Int());
            AddColumn("dbo.Mechs", "BaseWalkingMP", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "BaseCruisingMP", c => c.Int(nullable: false));
            AlterColumn("dbo.Forces", "ParentForceID", c => c.Int());
            AlterColumn("dbo.Machines", "ForceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Machines", "ForceID");
            CreateIndex("dbo.Forces", "ParentForceID");
            AddForeignKey("dbo.Machines", "ForceID", "dbo.Forces", "ForceID", cascadeDelete: true);
            DropColumn("dbo.Mechs", "MechWarrior_CrewID");
            DropColumn("dbo.Mechs", "MechWarriorID");
            DropColumn("dbo.Vehicles", "Crew_CrewID");
            DropColumn("dbo.Vehicles", "CruisingMP");
            DropTable("dbo.Crew");
            DropTable("dbo.CombatVehicleCrew");
            DropTable("dbo.MechWarriors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MechWarriors",
                c => new
                    {
                        CrewID = c.Int(nullable: false),
                        GunnerySkill = c.Int(nullable: false),
                        PilotingSkill = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CrewID);
            
            CreateTable(
                "dbo.CombatVehicleCrew",
                c => new
                    {
                        CrewID = c.Int(nullable: false),
                        DrivingSkill = c.Int(nullable: false),
                        GunnerySkill = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CrewID);
            
            CreateTable(
                "dbo.Crew",
                c => new
                    {
                        CrewID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CrewID);
            
            AddColumn("dbo.Vehicles", "CruisingMP", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "Crew_CrewID", c => c.Int());
            AddColumn("dbo.Mechs", "MechWarriorID", c => c.Int(nullable: false));
            AddColumn("dbo.Mechs", "MechWarrior_CrewID", c => c.Int());
            DropForeignKey("dbo.Machines", "ForceID", "dbo.Forces");
            DropForeignKey("dbo.Characters", "CharacterID", "dbo.Machines");
            DropIndex("dbo.Forces", new[] { "ParentForceID" });
            DropIndex("dbo.Machines", new[] { "ForceID" });
            DropIndex("dbo.Characters", new[] { "CharacterID" });
            AlterColumn("dbo.Machines", "ForceID", c => c.Int());
            AlterColumn("dbo.Forces", "ParentForceID", c => c.Int(nullable: false));
            DropColumn("dbo.Vehicles", "BaseCruisingMP");
            DropColumn("dbo.Mechs", "BaseWalkingMP");
            DropColumn("dbo.Machines", "CharacterID");
            DropTable("dbo.Characters");
            RenameColumn(table: "dbo.Forces", name: "ParentForceID", newName: "ParentForce_ForceID");
            RenameColumn(table: "dbo.Machines", name: "ForceID", newName: "Force_ForceID");
            AddColumn("dbo.Forces", "ParentForceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "Crew_CrewID");
            CreateIndex("dbo.MechWarriors", "CrewID");
            CreateIndex("dbo.Mechs", "MechWarrior_CrewID");
            CreateIndex("dbo.CombatVehicleCrew", "CrewID");
            CreateIndex("dbo.Machines", "Force_ForceID");
            CreateIndex("dbo.Forces", "ParentForce_ForceID");
            AddForeignKey("dbo.Machines", "Force_ForceID", "dbo.Forces", "ForceID");
            AddForeignKey("dbo.Vehicles", "Crew_CrewID", "dbo.CombatVehicleCrew", "CrewID");
            AddForeignKey("dbo.MechWarriors", "CrewID", "dbo.Crew", "CrewID");
            AddForeignKey("dbo.Mechs", "MechWarrior_CrewID", "dbo.MechWarriors", "CrewID");
            AddForeignKey("dbo.CombatVehicleCrew", "CrewID", "dbo.Crew", "CrewID");
        }
    }
}
