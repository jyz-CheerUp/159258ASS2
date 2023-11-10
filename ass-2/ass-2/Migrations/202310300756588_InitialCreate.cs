namespace ass_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Images = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        steps = c.String(),
                        material = c.String(),
                        Image = c.String(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dishes", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Dishes", new[] { "CategoryID" });
            DropTable("dbo.Dishes");
            DropTable("dbo.Categories");
        }
    }
}
