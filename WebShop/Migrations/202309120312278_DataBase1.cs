namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Category", "Alias", c => c.String());
            AddColumn("dbo.tbl_New", "Alias", c => c.String());
            AddColumn("dbo.tbl_Post", "Alias", c => c.String());
            AddColumn("dbo.tbl_Product", "Alias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Product", "Alias");
            DropColumn("dbo.tbl_Post", "Alias");
            DropColumn("dbo.tbl_New", "Alias");
            DropColumn("dbo.tbl_Category", "Alias");
        }
    }
}
