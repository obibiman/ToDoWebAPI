using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Models;
using ToDo.WebAPI.Models;

namespace ToDo.WebAPI.Context
{
    /// <summary>
    /// TodoContext
    /// </summary>
    public class TodoContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TodoContext()
        {
                
        }
        /// <summary>
        /// Constructor for TodoContext
        /// </summary>
        /// <param name="options"></param>
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// TodoItems
        /// </summary>
        public DbSet<TodoItem> TodoItems { get; set; }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 1, Name = "Joseph Yomego", IsComplete = true, Secret = "Top secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 2, Name = "Mary Masjid", IsComplete = true, Secret = "Internal use only" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 3, Name = "Jane Arune", IsComplete = false, Secret = "For your eyes only" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 4, Name = "Peter Polonne", IsComplete = true, Secret = "Classified" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 5, Name = "Brenda Williams", IsComplete = true, Secret = "Confidential" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 6, Name = "Erica Gage", IsComplete = true, Secret = "Lega Department" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 7, Name = "James Garcia", IsComplete = false, Secret = "Open secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 8, Name = "Roseanne Pelosi", IsComplete = true, Secret = "Internal use only" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 9, Name = "Josh Krueger", IsComplete = true, Secret = "Top secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 10, Name = "Raymona Edwards", IsComplete = true, Secret = "HR Use only" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 11, Name = "Aisha Plank", IsComplete = true, Secret = "Public Use" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 12, Name = "Larry Latham", IsComplete = true, Secret = "To secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 13, Name = "Maurice Martinez", IsComplete = true, Secret = "Unclassified" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 14, Name = "Richard Berry", IsComplete = true, Secret = "HR Use only" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 15, Name = "Thomas O'Toole", IsComplete = true, Secret = "Public Use" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 16, Name = "Michelle Chen", IsComplete = true, Secret = "To secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 17, Name = "Andrea Rodriguez", IsComplete = true, Secret = "Unclassified" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 18, Name = "Jolene Perdue", IsComplete = true, Secret = "To secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 19, Name = "JoAnne Washington", IsComplete = true, Secret = "To secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 20, Name = "Gregory Ward", IsComplete = true, Secret = "To secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 21, Name = "John Greene", IsComplete = true, Secret = "Unclassified" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 22, Name = "Ron Kilgen", IsComplete = true, Secret = "To secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 23, Name = "Matthew Plummer", IsComplete = true, Secret = "HR Use only" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 24, Name = "Fred O'Neal", IsComplete = true, Secret = "Public Use" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 25, Name = "Lorne DeBlasio", IsComplete = true, Secret = "To secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 26, Name = "Brian Worley", IsComplete = true, Secret = "To secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 27, Name = "Timothy Bosley", IsComplete = true, Secret = "To secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 28, Name = "Les Millard", IsComplete = true, Secret = "To secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 29, Name = "Marlon Ethridge", IsComplete = true, Secret = "To secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 30, Name = "Phil DeGrasso", IsComplete = true, Secret = "To secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 31, Name = "Grant Guiliani", IsComplete = true, Secret = "To secret" });
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem() { Id = 32, Name = "Cory Cuomo", IsComplete = true, Secret = "To secret" });
        }
    }
}