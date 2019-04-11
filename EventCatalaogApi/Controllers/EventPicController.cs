using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EventCatalaogApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventPicController : ControllerBase
    {
        private readonly IHostingEnvironment _env;

        public EventPicController(IHostingEnvironment env)
        {
            _env = env;


        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Getimage(int id)
        {
            var webroot = _env.WebRootPath;
            var path = Path.Combine(webroot + "/EventPics/", "Event-" + id + ".jpg");
            var buffer = System.IO.File.ReadAllBytes(path);
            return File(buffer, "image/jpg");

        }
    }
}
