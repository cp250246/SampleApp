using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Models;
using SampleApp.Services;

namespace SampleApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : Controller
    {
        private readonly JsonPlaceholderClient _jsonPlaceholderClient;

        public AlbumController(JsonPlaceholderClient jsonPlaceholderClient)
        {
            _jsonPlaceholderClient = jsonPlaceholderClient;
        }

        [HttpGet]
        public async Task<IEnumerable<Albums>> Get()
        {
            var albums = await _jsonPlaceholderClient.GetAlbums();
            return albums;
        }
        
        [HttpGet ("{userID:long}")]
        public async Task<IEnumerable<Albums>> Get(long userId)
        {
            var albums = await _jsonPlaceholderClient.GetAlbums(userId);
            return albums;
        }
    }
}