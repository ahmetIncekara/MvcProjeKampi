namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_delete_add_message : DbMigration
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
