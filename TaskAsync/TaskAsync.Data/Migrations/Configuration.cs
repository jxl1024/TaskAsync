namespace TaskAsync.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaskAsync.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskAsync.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskAsync.Data.AppDbContext context)
        {
            List<Student> list = new List<Student>()
            {
                new Student()
                {
                    Name="Jack",
                    Age=23,
                    Gender=1
                },
                new Student()
                {
                    Name="Tom",
                    Age=25,
                    Gender=2
                }
            };

            if(!context.Students.Any())
            {
                context.Students.AddRange(list);
            }
        }
    }
}
