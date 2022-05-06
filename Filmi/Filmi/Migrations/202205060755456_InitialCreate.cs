namespace Filmi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Žanra = c.String(),
                        LetoIzdaje = c.Int(nullable: false),
                        Režiserid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Režiser", t => t.Režiserid, cascadeDelete: true)
                .Index(t => t.Režiserid);
            
            CreateTable(
                "dbo.Režiser",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Priimek = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "Režiserid", "dbo.Režiser");
            DropIndex("dbo.Films", new[] { "Režiserid" });
            DropTable("dbo.Režiser");
            DropTable("dbo.Films");
        }
    }
}
