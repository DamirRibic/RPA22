namespace Filmi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Igralecs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Priimek = c.String(),
                        Filmid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Films", t => t.Filmid, cascadeDelete: true)
                .Index(t => t.Filmid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Igralecs", "Filmid", "dbo.Films");
            DropIndex("dbo.Igralecs", new[] { "Filmid" });
            DropTable("dbo.Igralecs");
        }
    }
}
