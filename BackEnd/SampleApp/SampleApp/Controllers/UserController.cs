using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Models;
using SampleApp.Services;

namespace SampleApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly JsonPlaceholderClient _jsonPlaceholderClient;

        public UserController(JsonPlaceholderClient jsonPlaceholderClient)
        {
            _jsonPlaceholderClient = jsonPlaceholderClient;
        }

        [HttpGet]
        public async Task<IEnumerable<Users>> Get()
        {
            var users = await _jsonPlaceholderClient.GetUsers();
            return users;
        }
    }
}