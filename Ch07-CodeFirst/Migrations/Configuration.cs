namespace Ch07_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Ch07_CodeFirst.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Ch07_CodeFirst.Models.CmsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ch07_CodeFirst.Models.CmsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Employees.AddOrUpdate(
                x => x.Id,
                new Employee { Id = 1, Name = "David", Mobile = "0933-152667", Email = "david@gmail.com", Department = "羆竒瞶", Title = "CEO" },
                new Employee { Id = 2, Name = "Mary", Mobile = "0938-456889", Email = "mary@gmail.com", Department = "ㄆ场", Title = "恨瞶畍" },
                new Employee { Id = 3, Name = "Joe", Mobile = "0925-331225", Email = "joe@gmail.com", Department = "癩叭场", Title = "竒瞶" },
                new Employee { Id = 4, Name = "Mark", Mobile = "0935-863991", Email = "mark@gmail.com", Department = "穨叭场", Title = "穨叭" },
                new Employee { Id = 5, Name = "Rose", Mobile = "0987-335668", Email = "rose@gmail.com", Department = "戈癟场", Title = "祘畍" }
                );

            context.Registers.AddOrUpdate(
                x => x.Id,
                new Register { Id = 1, Name = "甇地", Nickname = "竧返步", Password = "myPassword*", Email = "dotnetcool@gmail.com", City = 4, Gender = 1, Commutermode = "1", Comment = "Nothing", Terms = true }
                );
        }
    }
}
