using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace car_magazine
{
    public class DataSeeder : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Categories OFF");

            var categories = new List<Category>
    {
        new Category { Name = "Sedan" },
        new Category { Name = "SUV" },
        new Category { Name = "Truck" },
    };

            categories.ForEach(category => context.Categories.Add(category));
            context.SaveChanges();
        }

    }
}
