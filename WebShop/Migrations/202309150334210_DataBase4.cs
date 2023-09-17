namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Product", "ProductCode", c => c.String(maxLength: 50));
            AlterColumn("dbo.tbl_Product", "Alias", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Product", "Alias", c => c.String());
            DropColumn("dbo.tbl_Product", "ProductCode");
        }
    }
}
