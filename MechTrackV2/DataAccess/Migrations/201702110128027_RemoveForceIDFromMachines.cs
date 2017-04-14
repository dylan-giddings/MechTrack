namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveForceIDFromMachines : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Machines", "ForceID", "dbo.Forces");
            DropIndex("dbo.Machines", new[] { "ForceID" });
            RenameColumn(table: "dbo.Machines", name: "ForceID", newName: "Force_ForceID");
            AlterColumn("dbo.Machines", "Force_ForceID", c => c.Int());
            CreateIndex("dbo.Machines", "Force_ForceID");
            AddForeignKey("dbo.Machines", "Force_ForceID", "dbo.Forces", "ForceID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Machines", "Force_ForceID", "dbo.Forces");
            DropIndex("dbo.Machines", new[] { "Force_ForceID" });
            AlterColumn("dbo.Machines", "Force_ForceID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Machines", name: "Force_ForceID", newName: "ForceID");
            CreateIndex("dbo.Machines", "ForceID");
            AddForeignKey("dbo.Machines", "ForceID", "dbo.Forces", "ForceID", cascadeDelete: true);
        }
    }
}
