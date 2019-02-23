using BabelSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BabelSample.Controllers
{
    [RoutePrefix("api/todos")]
    public class TodoController : ApiController
    {
        private static List<Todo> Todos = new List<Todo>() { new Todo() { Description = "todo 1" }, new Todo() { Description = "todo 2" }, new Todo() { Description = "todo 3" } };

        [Route("")]
        [HttpGet]
        public List<Todo> GetTodos()
        {
            return Todos;
        }
    }
}
