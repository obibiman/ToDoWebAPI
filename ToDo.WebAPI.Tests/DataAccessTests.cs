using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Models;
using ToDo.WebAPI.Context;
using Xunit;

namespace ToDo.WebAPI.Tests
{
    public class TodoContestTest
    {
        [Fact]
        public void ShouldbeAbletoCreateDatabase_InsertRecords()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "database_name")
                .Options;

            using (var ctx = new TodoContext(options))
            {
                var numTodos = new List<TodoItem>()
                {
                    new TodoItem { Id = 1, Name = "Joseph Yomego", IsComplete = true, Secret = "Top secret" },
                    new TodoItem { Id = 2, Name = "Mary Masjid", IsComplete = true, Secret = "Internal use only" }
                };
                ctx.TodoItems.AddRangeAsync(numTodos);
                ctx.SaveChangesAsync();

                Assert.Equal(2, ctx.TodoItems.Count());
            }

        }
    }
}