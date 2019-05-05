using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebMvc.Services;
using WebMvc.Models;
using WebMvc.Models.CartModels;
using Polly.CircuitBreaker;

namespace WebMvc.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        
        private readonly ICartService _cartService;
        private readonly IEventCatalogService _catalogService;
        private readonly IIdentityService<ApplicationUser> _identityService;

        public CartController(IIdentityService<ApplicationUser> identityService, ICartService cartService, IEventCatalogService catalogService)
        {
            _identityService = identityService;
            _cartService = cartService;
            _catalogService = catalogService;



        }
        public    IActionResult  Index()
        {
                       return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Dictionary<string, int> quantities, string action)
        {
            if (action == "[ Checkout ]")
            {
                return RedirectToAction("Create", "Order");
            }


            try
            {
                var user = _identityService.Get(HttpContext.User);
                var basket = await _cartService.SetQuantities(user, quantities);
                var vm = await _cartService.UpdateCart(basket);

            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in open circuit  mode                 
                HandleBrokenCircuitException();
            }

            return View();

        }

            public async Task<IActionResult> AddToCart(EventCatalogItem productDetails)
        {
            try
            {
                if (productDetails.Id != null)
                {
                    var user = _identityService.Get(HttpContext.User);
                    var product = new CartItem()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Quantity = 1,
                        ProductName = productDetails.Name,
                        PictureUrl = productDetails.PictureUrl,
                        UnitPrice = productDetails.Price,
                        ProductId = productDetails.Id
                    };
                    await _cartService.AddItemToCart(user, product);
                }
                return RedirectToAction("Index", "EventCatalog");
            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in circuit-opened mode                 
                HandleBrokenCircuitException();
            }

            return RedirectToAction("Index", "EventCatalog");

        }
       
        private void HandleBrokenCircuitException()
        {
            TempData["BasketInoperativeMsg"] = "cart Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
        }

    }
}