namespace Seminarska.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Filmis", "Režiserjiid");
            CreateIndex("dbo.Igralcis", "Filmiid");
            AddForeignKey("dbo.Filmis", "Režiserjiid", "dbo.Režiserji", "id", cascadeDelete: true);
            AddForeignKey("dbo.Igralcis", "Filmiid", "dbo.Filmis", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Igralcis", "Filmiid", "dbo.Filmis");
            DropForeignKey("dbo.Filmis", "Režiserjiid", "dbo.Režiserji");
            DropIndex("dbo.Igralcis", new[] { "Filmiid" });
            DropIndex("dbo.Filmis", new[] { "Režiserjiid" });
        }
    }
}
