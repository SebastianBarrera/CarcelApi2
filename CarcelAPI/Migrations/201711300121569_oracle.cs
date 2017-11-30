namespace CarcelAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oracle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "carcel.CondenaDelitos",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CondenaId = c.Decimal(precision: 10, scale: 0),
                        DelitoId = c.Decimal(precision: 10, scale: 0),
                        Condena = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("carcel.Condenas", t => t.CondenaId)
                .Index(t => t.CondenaId);
            
            CreateTable(
                "carcel.Condenas",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FechaInicioCondena = c.DateTime(nullable: false),
                        FechaCondena = c.DateTime(nullable: false),
                        PresoId = c.Decimal(precision: 10, scale: 0),
                        JuezId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("carcel.Jueces", t => t.JuezId)
                .ForeignKey("carcel.Presos", t => t.PresoId)
                .Index(t => t.PresoId)
                .Index(t => t.JuezId);
            
            CreateTable(
                "carcel.Jueces",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nombre = c.String(maxLength: 50),
                        Rut = c.String(maxLength: 20),
                        Domicilio = c.String(maxLength: 100),
                        Sexo = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "carcel.Presos",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Rut = c.String(maxLength: 20),
                        Nombre = c.String(maxLength: 50),
                        Apellido = c.String(maxLength: 50),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Domicilio = c.String(maxLength: 100),
                        Sexo = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "carcel.Delitos",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nombre = c.String(maxLength: 50),
                        CondenaMinima = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CondenaMaxima = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("carcel.CondenaDelitos", "CondenaId", "carcel.Condenas");
            DropForeignKey("carcel.Condenas", "PresoId", "carcel.Presos");
            DropForeignKey("carcel.Condenas", "JuezId", "carcel.Jueces");
            DropIndex("carcel.Condenas", new[] { "JuezId" });
            DropIndex("carcel.Condenas", new[] { "PresoId" });
            DropIndex("carcel.CondenaDelitos", new[] { "CondenaId" });
            DropTable("carcel.Delitos");
            DropTable("carcel.Presos");
            DropTable("carcel.Jueces");
            DropTable("carcel.Condenas");
            DropTable("carcel.CondenaDelitos");
        }
    }
}
