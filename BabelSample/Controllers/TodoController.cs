using BabelSample.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BabelSample.Controllers
{
    [RoutePrefix("api/todos")]
    public class TodoController : ApiController
    {
        private static List<Todo> Todos = new List<Todo>()
        {
            new Todo() { Id = 1, Description = "todo 1", IsDone = false },
            new Todo() { Id = 2, Description = "todo 2", IsDone = false },
            new Todo() { Id = 3, Description = "todo 3", IsDone = false }
        };

        [Route("")]
        [HttpGet]
        public List<Todo> GetTodos()
        {
            return Todos;
        }

        [Route("")]
        [HttpPost]
        public Todo CreateTodo([FromBody]string description)
        {
            var lastTodo = Todos.LastOrDefault();
            var id = lastTodo != null ? lastTodo.Id + 1 : 1;
            var result = new Todo() { Id = id, Description = description, IsDone = false };
            Todos.Add(result);
            return result;
        }

        [Route("")]
        [HttpPut]
        public string UpdateTodo([FromBody]TodoPutDto dto)
        {
            var todo = Todos.Single(x => x.Id == dto.Id);
            todo.IsDone = dto.IsDone;
            return todo.Description;
        }

        [Route("")]
        public bool DeleteTodo([FromBody]int id)
        {
            var todo = Todos.Single(x => x.Id == id);
            Todos.Remove(todo);
            return true;
        }
    }
}
