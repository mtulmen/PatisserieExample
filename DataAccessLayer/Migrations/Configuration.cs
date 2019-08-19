namespace DataAccessLayer.Migrations
{
    using DataAccessLayer.MyEntities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.Model1 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Model1 ctx = new Model1();
            Cake pat = new Cake();
            pat.Id = 1;
            pat.ImageUrl = "1.jpg";
            pat.Name = "lemon cheese Cake ";
            pat.Price = 10.5M;
            pat.Description = "a delicious cake with lemon";

            ctx.Cakes.AddOrUpdate(pat);

            Cake pat1 = new Cake();
            pat1.Id = 2;
            pat1.ImageUrl = "2.jpg";
            pat1.Name = "strawberry cheeseCake";
            pat1.Price = 10.5M;
            pat1.Description = "a delicious cake with lemon";

            ctx.Cakes.AddOrUpdate(pat1);

            Cake pat2 = new Cake();
            pat2.Id = 3;
            pat2.ImageUrl = "3.jpg";
            pat2.Name = "cheese Cake with blueberry";
            pat2.Price = 10.5M;
            pat2.Description = "a delicious cake with lemon";

            ctx.Cakes.AddOrUpdate(pat2);

            Cake pat3 = new Cake();
            pat3.Id = 4;
            pat3.ImageUrl = "4.jpg";
            pat3.Name = "birthdate cake";
            pat3.Price = 10.5M;
            pat3.Description = "a description for birthday cake";

            ctx.Cakes.AddOrUpdate(pat3);


            Cake pat4 = new Cake();
            pat4.Id = 5;
            pat4.ImageUrl = "5.jpg";
            pat4.Name = "birthdate cake1";
            pat4.Price = 10.5M;
            pat4.Description = "a description for birthday cake";

            ctx.Cakes.AddOrUpdate(pat4);

            Cake pat5 = new Cake();
            pat5.Id = 6;
            pat5.ImageUrl = "6.jpg";
            pat5.Name = "birthdate cake2";
            pat5.Price = 10.5M;
            pat5.Description = "another description for birthday cake";

            ctx.Cakes.AddOrUpdate(pat5);

            ctx.SaveChanges();

        }
    }
}
