using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class CatalogIndexViewModel
    {

        public PaginationInfo PaginationInfo { get; set; }

        public IEnumerable<EventCatalogItem> EventCatalogItems { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public IEnumerable<SelectListItem> Places { get; set; }

        public int? CategoryFilterApplied { get; set; }

        public int? PlaceFilterApplied { get; set; }


    }
}
