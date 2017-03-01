namespace NewsPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Image = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ContentId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Content_ContentId = c.Int(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Contents", t => t.Content_ContentId)
                .Index(t => t.Content_ContentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 20),
                        PhoneNumber = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Images", "Content_ContentId", "dbo.Contents");
            DropIndex("dbo.Users", new[] { "Role_RoleId" });
            DropIndex("dbo.Images", new[] { "Content_ContentId" });
            DropIndex("dbo.Contents", new[] { "User_UserId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Images");
            DropTable("dbo.Contents");
        }
    }
}
