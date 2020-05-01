using AutoMapper;
using ToDo.Domain.Models;

namespace ToDo.WebAPI.Models
{
    /// <summary>
    /// TodoItemProfile
    /// </summary>
    public class TodoItemProfile : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TodoItemProfile()
        {
            CreateMap<TodoItem, TodoItemDTO>().ReverseMap();
        }
    }
}