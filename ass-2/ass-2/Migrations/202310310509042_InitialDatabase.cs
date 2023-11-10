namespace ass_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "Dishes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dishes", "Dishes");
        }
    }
}
