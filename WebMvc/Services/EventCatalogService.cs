using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class EventCatalogService : IEventCatalogService
    {

        private readonly string _remoteServiceBaseUri ;
        private readonly IHttpClient _httpclient;
       


        public EventCatalogService(IHttpClient httpClient, IConfiguration configuration)
        {
            _httpclient = httpClient;

            _remoteServiceBaseUri = $"{configuration["EventCatalogUrl"]}/api/EventCatalog/";
        }
        public async Task<EventCatalog> GetcatalogItemsAsync(int page, int take, int? category, int? Place)
        {
           var EventCatalogItemsUri= ApiPaths.Eventcatalog.GetAllEventCatalogItems(_remoteServiceBaseUri, page, take, category,Place);
          var datastring = await  _httpclient.GetStringAsync(EventCatalogItemsUri);
           var response= JsonConvert.DeserializeObject<EventCatalog>(datastring);
            return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var EventcategoryUri = ApiPaths.Eventcatalog.GetAllEventCategory(_remoteServiceBaseUri);
            var datastring = await _httpclient.GetStringAsync(EventcategoryUri);
            var items = new List<SelectListItem>
             {
                 new SelectListItem
                 {
                     Value=null,
                     Text="All",
                     Selected=true
                 }
             };
            var categories = JArray.Parse(datastring);
            foreach(var category in categories)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = category.Value<String>("id"),
                        Text = category.Value<string>("category")

                    });

            }

            return items;
        }

       

        public async Task<IEnumerable<SelectListItem>> GetPlacesAsync()
        {

            var EventplaceUri = ApiPaths.Eventcatalog.GetAllEventPlaces(_remoteServiceBaseUri);
            var datastring = await _httpclient.GetStringAsync(EventplaceUri);
            var items = new List<SelectListItem>
             {
                 new SelectListItem
                 {
                     Value=null,
                     Text="All",
                     Selected=true
                 }
             };
            var places = JArray.Parse(datastring);
            foreach (var place in places)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = place.Value<String>("id"),
                        Text = place.Value<string>("place")

                    });

            }

            return items;

        }
    }
}
