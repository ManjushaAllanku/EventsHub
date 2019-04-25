using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{
    public class EventCatalogItem
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Address { get; set; }

        public String City { get; set; }

        public string Datetime { get; set; }

        public decimal Price { get; set; }

        public String PictureUrl { get; set; }

        public String Description { get; set; }

        public int EventCategoryId { get; set; }

        public int EventPlaceId { get; set; }

        public String EventCategory { get; set; }

        public String EventPlace { get; set; }
        




    }
}
