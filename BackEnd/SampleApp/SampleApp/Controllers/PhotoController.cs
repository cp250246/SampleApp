using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Models;
using SampleApp.Services;

namespace SampleApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : Controller
    {
        private readonly JsonPlaceholderClient _jsonPlaceholderClient;

        public PhotoController(JsonPlaceholderClient jsonPlaceholderClient)
        {
            _jsonPlaceholderClient = jsonPlaceholderClient;
        }

        [HttpGet ("{albumID:long}")]
        public async Task<IEnumerable<Photos>> Get(long albumID)
        {
            var photos = await _jsonPlaceholderClient.GetPhotos(albumID);
            return photos;
        }
    }
}