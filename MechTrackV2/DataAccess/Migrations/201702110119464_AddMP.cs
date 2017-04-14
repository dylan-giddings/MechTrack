namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "CruisingMP", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "CruisingMP");
        }
    }
}
