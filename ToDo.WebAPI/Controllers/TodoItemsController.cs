using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.WebAPI.Context;
using ToDo.WebAPI.Models;
using ToDo.WebAPI.Services.Contracts;

namespace ToDo.WebAPI.Controllers
{
    /// <summary>
    /// TodoItemsController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// Controller
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public TodoItemsController(ITodoItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        /// <summary>
        /// GetTodoItems
        /// </summary>
        /// <returns>List of Todo items</returns>
        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            var todoItems = await _repo.GetAllAsync();
            var mappedTodoItem = _mapper.Map<List<TodoItemDTO>>(todoItems);
            return mappedTodoItem;
        }

        /// <summary>
        /// GetTodoItem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(int id)
        {
            var todoItem = await _repo.GetByIdAsync(id);
            var mappedTodoItem = _mapper.Map<TodoItemDTO>(todoItem);

            if (mappedTodoItem == null)
            {
                return NotFound();
            }

            return mappedTodoItem;
        }


        /// <summary>
        /// GetTodoItemFiltered
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>TodoItem filtered by parameter</returns>
        [HttpGet]
        [Route("filterone")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItemFiltered(Expression<Func<TodoItem, bool>> predicate)
        {
            var todoItem = await _repo.GetFilteredAsync(predicate);
            var mappedTodoItem = _mapper.Map<TodoItemDTO>(todoItem);

            if (mappedTodoItem == null)
            {
                return NotFound();
            }

            return mappedTodoItem;
        }


        /// <summary>
        /// GetTodoItemsFiltered
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>List of TodoItems filtered by parameter</returns>
        [HttpGet]
        [Route("filterall")]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItemsFiltered(Expression<Func<TodoItem, bool>> predicate = null)
        {
            var todoItem = await _repo.GetAllFilteredAsync(predicate);
            var mappedTodoItem = _mapper.Map<List<TodoItemDTO>>(todoItem);

            if (mappedTodoItem == null)
            {
                return NotFound();
            }

            return mappedTodoItem;
        }


        /// <summary>
        /// PutTodoItem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todoItem"></param>
        /// <returns>Single TodoItem</returns>
        // PUT: api/TodoItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repo.UpdateAsync(todoItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await TodoItemExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        /// <summary>
        /// PostTodoItem
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns>Single TodoItem</returns>
        // POST: api/TodoItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
          var done = await  _repo.CreateAsync(todoItem);

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        /// <summary>
        /// AddListOfItems
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>No return value</returns>
        [HttpPost]
        [Route("additems")]
        public async Task AddToDoItems(IEnumerable<TodoItem> entities)
        {
             await _repo.AddRangeAsync(entities);
        }

        /// <summary>
        /// DeleteTodoItem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(int id)
        {
            var todoItem = await _repo.GetByIdAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            await _repo.DeleteAsync(todoItem);

            return todoItem;
        }
       
        /// <summary>
        /// DeleteTodoItems
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>No return value</returns>
        [HttpDelete]
        [Route("deleteitems")]
        public async Task DeleteTodoItems(IEnumerable<TodoItem> entities)
        {
            await _repo.RemoveRangeAsync(entities);         
        }

        /// <summary>
        /// TodoItemExistsAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true or false</returns>
        private async Task< bool> TodoItemExistsAsync(int id)
        {
            var todoItems = await _repo.GetAllAsync();
            return (todoItems.Where(y => y.Id == id).Any());
        }
    }
}