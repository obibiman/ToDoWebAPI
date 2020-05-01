using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
