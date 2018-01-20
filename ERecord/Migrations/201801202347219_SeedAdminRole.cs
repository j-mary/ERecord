namespace ERecord.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [IsActive], [Address], [City], [State], [Nationality], [Gender], [Dob], [MaritalStatus], [NumberOfChildren], [EmploymentDay], [SchoolAttended], [MaximumQulaification], [ServiceYear], [LastPromoted], [YearlySalary], [DateCreated]) VALUES (N'48853654-1dfc-4fda-8519-eb6c17f70d47', N'admin@erecord.com', 0, N'ALeZzjT7e9bWdyr3C6lO/33mHpadoH3n8LJhNgOZiMGVclIsruVPOXhwp90NbsAQEA==', N'83aae2d7-f23d-4d9c-a1c2-49307ad46efb', N'08020333465', 0, 0, NULL, 1, 0, N'admin@erecord.com', N'Admin', N'User', 1, N'Surulere', N'Lagos', 36, 150, 0, N'1987-04-05 00:00:00', 0, 0, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'2018-01-21 00:44:16')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [IsActive], [Address], [City], [State], [Nationality], [Gender], [Dob], [MaritalStatus], [NumberOfChildren], [EmploymentDay], [SchoolAttended], [MaximumQulaification], [ServiceYear], [LastPromoted], [YearlySalary], [DateCreated]) VALUES (N'd239f8d6-878b-4a8b-ae5c-da2dec98c7eb', N'guest@erecord.com', 0, N'AOy6KbNp3sYghVSHgrjoL4YRbZllwVGKt33UXe/4Zc+JaiQAWg0skRZlExPckS4lGA==', N'fcf7ea55-9ea2-4e66-8eb6-ce7c7d1f43e2', N'08020333461', 0, 0, NULL, 1, 0, N'guest@erecord.com', N'Guest', N'User', 0, N'Here', N'There', 37, 150, 1, N'2005-08-18 00:00:00', 0, 0, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), N'2018-01-21 00:00:00')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'06f9545e-db38-431b-8ce4-bce498c7077f', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'48853654-1dfc-4fda-8519-eb6c17f70d47', N'06f9545e-db38-431b-8ce4-bce498c7077f')

");
        }
        
        public override void Down()
        {
        }
    }
}
