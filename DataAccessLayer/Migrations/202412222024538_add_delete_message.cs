namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_delete_message : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Delete", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Delete");
        }
    }
}
