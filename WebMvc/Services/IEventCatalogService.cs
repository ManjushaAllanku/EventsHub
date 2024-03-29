﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.Services
{
   public  interface IEventCatalogService
    {
        Task<EventCatalog> GetcatalogItemsAsync(int page, int take, int? category, int? Places);

        Task <IEnumerable<SelectListItem>> GetCategoriesAsync();

        Task<IEnumerable<SelectListItem>> GetPlacesAsync();




    }
}
