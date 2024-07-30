using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Metadata;
using Todo2.Domain;

namespace Todo2.Infrastructure

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=todo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<toDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<toDo>().HasData(new toDo { taskNum = 1, taskName="2022 Exam",taskDue="3/8/2024" },
                new toDo { taskNum = 2, taskName = "Finish angular videos", taskDue = "12/8/2024" },
                new toDo { taskNum = 3, taskName = "Change gym workout routine", taskDue = "15/8/2024" }
            );
        }

    }
}
