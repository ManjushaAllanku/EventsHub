using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventCatalogController : Controller
    {

        private readonly IEventCatalogService _CatalogService;

        public EventCatalogController(IEventCatalogService eventCatalogService)
        {
            _CatalogService = eventCatalogService;
        }

        public  async Task<IActionResult> Index(int? categoryFilterApplied,int? placeFilterApplied,int? page)
        {
            var itemsOnPage = 10;
           var catalog=  await _CatalogService.GetcatalogItemsAsync(page ?? 0, itemsOnPage, categoryFilterApplied,
                                                                         placeFilterApplied);

            var vm = new CatalogIndexViewModel
            {

                EventCatalogItems = catalog.Data,
                Categories= await _CatalogService.GetCategoriesAsync(),
                Places=await _CatalogService.GetPlacesAsync(),
                CategoryFilterApplied=categoryFilterApplied?? 0,
                PlaceFilterApplied=placeFilterApplied??0,
                PaginationInfo= new PaginationInfo
                {
                    ActualPage= page?? 0,
                    ItemsPerPage=itemsOnPage,
                    TotalItems=catalog.Count,
                    TotalPages=(int) Math.Ceiling((decimal)catalog.Count/itemsOnPage)
                }


            };

            vm.PaginationInfo.PreviousPage = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";
            vm.PaginationInfo.NextPage = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";

          
            return View(vm);
        }


        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your Application description page.";
            return View();

        }

    }
}