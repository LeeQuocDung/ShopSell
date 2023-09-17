namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Post", "Alias", c => c.String(maxLength: 150));
            AlterColumn("dbo.tbl_Post", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.tbl_Post", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tbl_Post", "SeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.tbl_Post", "SeoKeywords", c => c.String(maxLength: 250));
            AlterColumn("dbo.tbl_Product", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.tbl_Product", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tbl_Product", "SeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.tbl_Product", "SeoKeywords", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Product", "SeoKeywords", c => c.String());
            AlterColumn("dbo.tbl_Product", "SeoDescription", c => c.String());
            AlterColumn("dbo.tbl_Product", "SeoTitle", c => c.String());
            AlterColumn("dbo.tbl_Product", "Image", c => c.String());
            AlterColumn("dbo.tbl_Post", "SeoKeywords", c => c.String());
            AlterColumn("dbo.tbl_Post", "SeoDescription", c => c.String());
            AlterColumn("dbo.tbl_Post", "SeoTitle", c => c.String());
            AlterColumn("dbo.tbl_Post", "Image", c => c.String());
            AlterColumn("dbo.tbl_Post", "Alias", c => c.String());
        }
    }
}
