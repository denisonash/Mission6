using System;
using Microsoft.EntityFrameworkCore;

namespace Mission6.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            //leave blank
        }

        public DbSet<Task> tasks { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
