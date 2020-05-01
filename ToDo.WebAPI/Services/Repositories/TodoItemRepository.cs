using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.WebAPI.Context;
using ToDo.WebAPI.Models;
using ToDo.WebAPI.Services.Contracts;

namespace ToDo.WebAPI.Services.Repositories
{
    /// <summary>
    /// TodoItemRepository
    /// </summary>
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoContext _ctxt;
        /// <summary>
        /// TodoItemRepository constructor
        /// </summary>
        /// <param name="ctxt"></param>
        public TodoItemRepository(TodoContext ctxt)
        {
            _ctxt = ctxt;
        }

        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Single TodoItem</returns>
        public async Task<TodoItem> GetByIdAsync(int Id)
        {
            var prodSku = await _ctxt.TodoItems.FirstOrDefaultAsync(y => y.Id == Id);
            return prodSku;
        }

        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns>Sngle TodoItem</returns>
        public async Task<TodoItem> CreateAsync(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException(nameof(todoItem));
            }
            _ctxt.Set<TodoItem>().Add(todoItem);
            await _ctxt.SaveChangesAsync();
            return todoItem;
        }

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns>Deletes single TodoItem</returns>
        public async Task DeleteAsync(TodoItem todoItem)
        {
            var prodSku = _ctxt.TodoItems.FirstOrDefaultAsync(y => y.Id == todoItem.Id);
            if (prodSku != null)
            {
                _ctxt.Set<TodoItem>().Remove(todoItem);
            }
            await _ctxt.SaveChangesAsync();
        }

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns>List of TodoItems</returns>
        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            List<TodoItem> prodSku = await _ctxt.TodoItems.ToListAsync();
            return prodSku;
        }

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns>List of TodoItems</returns>
        public async Task<TodoItem> UpdateAsync(TodoItem todoItem)
        {
            Task<TodoItem> prodSku = _ctxt.TodoItems.FirstOrDefaultAsync(y => y.Id == todoItem.Id);
            if (prodSku != null)
            {
                await _ctxt.SaveChangesAsync();
            }
            return todoItem;
        }       

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Single TodoItem</returns>
        public TodoItem GetById(int Id)
        {
            var prodSku = _ctxt.TodoItems.FirstOrDefault(y => y.Id == Id);
            return prodSku;
        }
    }
}
