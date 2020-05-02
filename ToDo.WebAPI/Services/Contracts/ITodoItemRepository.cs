using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.WebAPI.Models;

namespace ToDo.WebAPI.Services.Contracts
{
    /// <summary>
    /// ITodoItemRepository
    /// </summary>
    public interface ITodoItemRepository
    {
        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns>Create a Todo item</returns>
        Task<TodoItem> CreateAsync(TodoItem todoItem);
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns>Delete a Todo item</returns>
        Task DeleteAsync(TodoItem todoItem);
        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns>List of todo items</returns>
        Task<IEnumerable<TodoItem>> GetAllAsync();
        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Single Todo item</returns>
        Task<TodoItem> GetByIdAsync(int Id);
        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns>Updated Todo item</returns>
        Task<TodoItem> UpdateAsync(TodoItem todoItem);
        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Single Todo item</returns>
        TodoItem GetById(int Id);
        /// <summary>
        /// GetAsync
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Single Todo Item</returns>
        Task<TodoItem> GetFilteredAsync(Expression<Func<TodoItem, bool>> predicate);
        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>List of TodoItems</returns>
        Task<IEnumerable<TodoItem>> GetAllFilteredAsync(Expression<Func<TodoItem, bool>> predicate = null);
        /// <summary>
        /// AddRangeAsync
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>Nothis is returned</returns>
        Task AddRangeAsync(IEnumerable<TodoItem> entities);
        /// <summary>
        /// RemoveRangeAsync
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>No return value</returns>
        Task RemoveRangeAsync(IEnumerable<TodoItem> entities);
    }
}
