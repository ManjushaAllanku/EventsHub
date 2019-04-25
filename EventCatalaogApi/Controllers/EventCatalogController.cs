using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalaogApi.Data;
using EventCatalaogApi.Domain;
using EventCatalaogApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalaogApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventCatalogController : ControllerBase
    {
        private readonly EventCatalogContext _context;
        private readonly IConfiguration _config;
        public EventCatalogController(EventCatalogContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventCategory()
        {
            var events = await _context.EventCategories.ToListAsync();
            return Ok(events);
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventPlace()
        {
            var events = await _context.EventPlaces.ToListAsync();
            return Ok(events);
        }


        [HttpGet]
        [Route("events/{id:int}")]
        public async Task<IActionResult> GetEventsById(int Id)
        {
            var events = await _context.EventCatalogs.SingleOrDefaultAsync(E => E.Id == Id);
            if (events != null)
            {

                events.PictureUrl.Replace("http://externaleventcatalogbaseurltobereplaced",
                                          _config["ExternalEventCatalogBaseUrl"]);

                return Ok(events);
            }

            return NotFound();

        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Events(
               [FromQuery] int pageSize = 6,
               [FromQuery] int pageIndex = 0)
        {
            var itemsCount =
                await _context.EventCatalogs.LongCountAsync();

            var events = await _context.EventCatalogs
                .OrderBy(E => E.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            events = ChangePictureUrl(events);

            var model = new PaginatedEventsViewModel<EventCatalog>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemsCount,
                Data = events
            };
            return Ok(model);

        }


        private List<EventCatalog>
           ChangePictureUrl(List<EventCatalog> items)
        {
            items.ForEach(
                E => E.PictureUrl = E.PictureUrl
                    .Replace("http://externaleventcatalogbaseurltobereplaced"
                    , _config["ExternalEventCatalogBaseUrl"])
                );
            return items;
        }
    }
}

   
