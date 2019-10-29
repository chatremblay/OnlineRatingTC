namespace OnlineRatingTC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReviewRatingTypes",
                c => new
                    {
                        ReviewRatingTypeCd = c.Int(nullable: false, identity: true),
                        ReviewRatingTypeName = c.String(),
                    })
                .PrimaryKey(t => t.ReviewRatingTypeCd);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewsId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ServiceTypeCd = c.Int(nullable: false),
                        ReviewRatingTypeCd = c.Int(nullable: false),
                        Comments = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ReviewsId)
                .ForeignKey("dbo.ReviewRatingTypes", t => t.ReviewRatingTypeCd, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeCd, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ServiceTypeCd)
                .Index(t => t.ReviewRatingTypeCd);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        ServiceTypeCd = c.Int(nullable: false, identity: true),
                        ServiceTypeName = c.String(),
                    })
                .PrimaryKey(t => t.ServiceTypeCd);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reviews", "ServiceTypeCd", "dbo.ServiceTypes");
            DropForeignKey("dbo.Reviews", "ReviewRatingTypeCd", "dbo.ReviewRatingTypes");
            DropIndex("dbo.Reviews", new[] { "ReviewRatingTypeCd" });
            DropIndex("dbo.Reviews", new[] { "ServiceTypeCd" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.Reviews");
            DropTable("dbo.ReviewRatingTypes");
        }
    }
}
