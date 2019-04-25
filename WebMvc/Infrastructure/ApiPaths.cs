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
    
     
    }
}
