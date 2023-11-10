namespace ass_2.Migrations
{
    using ass_2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ass_2.Data.ass_2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ass_2.Data.ass_2Context";
        }

        protected override void Seed(ass_2.Data.ass_2Context context)
        {
            var Categories = new List<Category>
            {
                new Category
                {


                }
            };
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
