namespace ERecord.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeApplicationUserDatePropertyNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "EmploymentDay", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "ServiceYear", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "LastPromoted", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "DateCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LastPromoted", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "ServiceYear", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "EmploymentDay", c => c.DateTime(nullable: false));
        }
    }
}
