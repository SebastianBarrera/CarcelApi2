namespace CarcelAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarcelAPI.Models.CarcelDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarcelAPI.Models.CarcelDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Delitos.AddOrUpdate(d => d.ID,
                new Models.Delito { Nombre = "Homicidio", CondenaMinima = 5, CondenaMaxima = 20 },
                new Models.Delito { Nombre = "Femicidio", CondenaMinima = 5, CondenaMaxima = 20 },
                new Models.Delito { Nombre = "Robo con Intimidacion", CondenaMinima = 1, CondenaMaxima = 12 },
                new Models.Delito { Nombre = "Robo en lugar no habitado", CondenaMinima = 1, CondenaMaxima = 5 },
                new Models.Delito { Nombre = "Cohecho", CondenaMinima = 5, CondenaMaxima = 8 });

            context.Usuarios.AddOrUpdate(u => u.ID,
                new Models.Usuario { UserName = "sebastian", Password = "admin" },
                new Models.Usuario { UserName = "gaspar", Password = "1234"});
        }
    }
}
