namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCrewTPHtoTPT : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Crew", newName: "CombatVehicleCrew");
            DropForeignKey("dbo.MechWarriors", "CrewID", "dbo.Crew");
            DropForeignKey("dbo.Vehicles", "Crew_CrewID", "dbo.Crew");
            DropPrimaryKey("dbo.CombatVehicleCrew");
            CreateTable(
                "dbo.Crew",
                c => new
                    {
                        CrewID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CrewID);
            
            AlterColumn("dbo.CombatVehicleCrew", "CrewID", c => c.Int(nullable: false));
            AlterColumn("dbo.CombatVehicleCrew", "DrivingSkill", c => c.Int(nullable: false));
            AlterColumn("dbo.CombatVehicleCrew", "GunnerySkill", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CombatVehicleCrew", "CrewID");
            CreateIndex("dbo.CombatVehicleCrew", "CrewID");
            AddForeignKey("dbo.CombatVehicleCrew", "CrewID", "dbo.Crew", "CrewID");
            AddForeignKey("dbo.Vehicles", "Crew_CrewID", "dbo.CombatVehicleCrew", "CrewID");
            DropColumn("dbo.CombatVehicleCrew", "Name");
            DropColumn("dbo.CombatVehicleCrew", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CombatVehicleCrew", "Discriminator", c => c.String(maxLength: 128));
            AddColumn("dbo.CombatVehicleCrew", "Name", c => c.String());
            DropForeignKey("dbo.Vehicles", "Crew_CrewID", "dbo.CombatVehicleCrew");
            DropForeignKey("dbo.CombatVehicleCrew", "CrewID", "dbo.Crew");
            DropIndex("dbo.CombatVehicleCrew", new[] { "CrewID" });
            DropPrimaryKey("dbo.CombatVehicleCrew");
            AlterColumn("dbo.CombatVehicleCrew", "GunnerySkill", c => c.Int());
            AlterColumn("dbo.CombatVehicleCrew", "DrivingSkill", c => c.Int());
            AlterColumn("dbo.CombatVehicleCrew", "CrewID", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Crew");
            AddPrimaryKey("dbo.CombatVehicleCrew", "CrewID");
            AddForeignKey("dbo.Vehicles", "Crew_CrewID", "dbo.Crew", "CrewID");
            AddForeignKey("dbo.MechWarriors", "CrewID", "dbo.Crew", "CrewID");
            RenameTable(name: "dbo.CombatVehicleCrew", newName: "Crew");
        }
    }
}
