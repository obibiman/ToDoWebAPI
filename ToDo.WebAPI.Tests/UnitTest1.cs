using Microsoft.EntityFrameworkCore;
using System;
using ToDo.Domain.Models;
using ToDo.WebAPI.Context;
using Xunit;

namespace ToDo.WebAPI.Tests
{
    public class TodoContestTest
    {
        [Fact]
        public void ShouleBoAbleToAddInMemoryDatabase()
        {
            var guid = Guid.NewGuid();
            var builder = new DbContextOptionsBuilder<TodoContext>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(guid.ToString());

            using (var ctxt = new TodoContext(builder.Options))
            {
                ctxt.TodoItems.Add(new TodoItem() { Id = 1, Name = "Joseph Yomego", IsComplete = true, Secret = "Top secret" });
                ctxt.TodoItems.Add(new TodoItem() { Id = 2, Name = "Mary Masjid", IsComplete = true, Secret = "Internal use only" });
                ctxt.SaveChanges();

                Assert.Equal(2, ctxt.TodoItems.Count(p=>p.Name = "Joseph Yomego"));
            }

        }
    }
}