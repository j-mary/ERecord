namespace ERecord.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.AspNetUsers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "State", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Nationality", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Dob", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "MaritalStatus", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "NumberOfChildren", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "EmploymentDay", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "SchoolAttended", c => c.String());
            AddColumn("dbo.AspNetUsers", "MaximumQulaification", c => c.String());
            AddColumn("dbo.AspNetUsers", "ServiceYear", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastPromoted", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "YearlySalary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AspNetUsers", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DateCreated");
            DropColumn("dbo.AspNetUsers", "YearlySalary");
            DropColumn("dbo.AspNetUsers", "LastPromoted");
            DropColumn("dbo.AspNetUsers", "ServiceYear");
            DropColumn("dbo.AspNetUsers", "MaximumQulaification");
            DropColumn("dbo.AspNetUsers", "SchoolAttended");
            DropColumn("dbo.AspNetUsers", "EmploymentDay");
            DropColumn("dbo.AspNetUsers", "NumberOfChildren");
            DropColumn("dbo.AspNetUsers", "MaritalStatus");
            DropColumn("dbo.AspNetUsers", "Dob");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Nationality");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "IsActive");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
