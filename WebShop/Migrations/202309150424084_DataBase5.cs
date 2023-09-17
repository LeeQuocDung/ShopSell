namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_ProductCategory", "Alias", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.tbl_ProductCategory", "Desciption", c => c.String(maxLength: 250));
            AlterColumn("dbo.tbl_ProductCategory", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tbl_ProductCategory", "SeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.tbl_ProductCategory", "SeoKeywords", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_ProductCategory", "SeoKeywords", c => c.String());
            AlterColumn("dbo.tbl_ProductCategory", "SeoDescription", c => c.String());
            AlterColumn("dbo.tbl_ProductCategory", "SeoTitle", c => c.String());
            AlterColumn("dbo.tbl_ProductCategory", "Desciption", c => c.String());
            DropColumn("dbo.tbl_ProductCategory", "Alias");
        }
    }
}
