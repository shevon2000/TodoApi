using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Use static GUIDs and DateTime values
        builder.Entity<Todo>().HasData(
            new Todo
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Title = "Learn ASP.NET Core",
                Description = "Build a Web API with ASP.NET Core",
                IsCompleted = false,
                CreatedDate = new DateTime(2025, 4, 28) // Use a static date
            },
            new Todo
            {
                Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                Title = "Learn React",
                Description = "Build a frontend with React",
                IsCompleted = false,
                CreatedDate = new DateTime(2025, 4, 28) // Use a static date
            }
        );
    }
}
