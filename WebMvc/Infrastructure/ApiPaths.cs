using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public class ApiPaths
    {

        public static class Eventcatalog
        {

            public static string GetAllEventCatalogItems(string baseuri, int page, int take,
                                                          int? category, int? place)
            {

                var filterQs = String.Empty;

                if (category.HasValue || place.HasValue)
                {

                    var categoryQs = (category.HasValue) ? (category.Value.ToString()) : "null";
                    var placeQs = (place.HasValue) ? (place.Value.ToString()) : "null";
                    filterQs = $"/category/{categoryQs}/place/{placeQs}";

                }

                return $"{baseuri}Events{filterQs}?pageIndex={page}& pagesize={take}";


            }


            public static string GetAllEventCategory(String baseuri)
            {
                return $"{baseuri}EventCategory";


            }

            public static string GetAllEventPlaces(String baseuri)
            {
                return $"{baseuri}EventPlace";
            }


        }

        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

        }


        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            public static string GetOrders(string baseUri)
            {
                return baseUri;
            }
            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }
    }
}