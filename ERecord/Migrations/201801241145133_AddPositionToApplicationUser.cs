namespace ERecord.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPositionToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Position", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Position");
        }
    }
}
