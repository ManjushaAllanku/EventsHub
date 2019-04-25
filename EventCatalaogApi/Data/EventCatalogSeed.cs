using EventCatalaogApi.Data;
using EventCatalaogApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalaogApi.Data
{
    public class EventCatalogSeed
    {

       public static  void EventSeed(EventCatalogContext context)
        {
            context.Database.Migrate();
            if (!context.EventPlaces.Any())
            {
                context.EventPlaces.AddRange(GetPreconfiguredEventPlaces());
                context.SaveChanges();
            }
            if (!context.EventCategories.Any())
            {
                context.EventCategories.AddRange(GetPreconfiguredEventCategories());
                context.SaveChanges();

            }
            if (!context.EventCatalogs.Any())
            {
                context.EventCatalogs.AddRange(GetPreconfiguredEventatalogs());
                context.SaveChanges();
            }
        }

        private static IEnumerable<EventCatalog> GetPreconfiguredEventatalogs()
        {
            return new List<EventCatalog>()
            {
                new EventCatalog(){ EventCategoryId=1,EventPlaceId=3,Address="34 street,12345,Calofornia",City="dublin",Price=0,Datetime="sat & sun  evening 7.00 p.m. dec 10 , 11th ",Description="Christmas magical lane",Name="winter show",PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/1"},
                new EventCatalog(){ EventCategoryId=2,EventPlaceId=2,Address="12 street,14367,Boston",City="issquah",Price=5,Datetime="sunday morning 10.00 a.m.",Description="free paint for all ages",Name="Art for kids",PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/2"},
                new EventCatalog(){ EventCategoryId=3, EventPlaceId=3, Address="4 street,4563,Seattle", City="bellevue",Price=7, Datetime="nov 23rd to dec 25th ", Description="Christmas light show", Name="Light show", PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/3"},
                new EventCatalog(){ EventCategoryId=3, EventPlaceId=3, Address="71 street,4589,Newyork", City="Buffalo",Price=0, Datetime="saturday 10 a.m. to 3 p.m.", Description="Techinical and non technical job fair", Name="Job Fair", PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/4"},
                new EventCatalog(){ EventCategoryId=1, EventPlaceId=2, Address="37 street,46789,LA", City="LosAngeles",Price=15, Datetime="monday morning 8.00 a.m. june 1oth ", Description="world's biggest fiddler show", Name="Fiddler", PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/5"},
                new EventCatalog(){ EventCategoryId=2, EventPlaceId=1, Address="56 street,Bothell", City="Seattle",Price=6, Datetime="nov 23rd wednesday morning 10.00 a.m.", Description="christmas play", Name="A family Christmas", PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/6"},
                new EventCatalog(){ EventCategoryId=3, EventPlaceId=2, Address="73 street,4688,kennedy centerconcert hall",Price=13, City="dublin", Datetime="tuesday morning 10.00 a.m.", Description="musical ", Name="musical show", PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/7"},
                new EventCatalog(){ EventCategoryId=2, EventPlaceId=3, Address="454 street,34567,Calofornia", City="dublin",Price=7, Datetime="tuesday morning 10.00 a.m.", Description="holiparty", Name="holiparty2015", PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/8"},
                new EventCatalog(){ EventCategoryId=1, EventPlaceId=2, Address="1st street,85632,seattle", City="seattle", Price=0,Datetime="sep 6 ", Description="Science and Tech Fair", Name="HighSchool Science Fair", PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/9"},
                new EventCatalog(){ EventCategoryId=2, EventPlaceId=1, Address="34 street,12345,Calofornia", City="dublin",Price=12, Datetime="may 22- may 23", Description="BioScience Invotaion Day", Name="holiparty2015", PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/10"},
                new EventCatalog(){ EventCategoryId=2, EventPlaceId=2, Address="98 street,36789,wa", City="burlington", Price=23,Datetime="april 8- 10", Description="AgileGme Development", Name="Agile Games", PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/11"},
                new EventCatalog(){ EventCategoryId=3, EventPlaceId=3, Address="134 street,12345,Calofornia", City="texas",Price=15, Datetime="dec 14-dec 19 2019", Description="laser lights", Name="Dragon Light show", PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/12"},
                new EventCatalog(){ EventCategoryId=1, EventPlaceId=2, Address="8 street,6789,Bellevue", City="Bellevue",Price=8, Datetime="oct 4", Description="nut cracker balley", Name="Balley", PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/13"},
                new EventCatalog(){ EventCategoryId=1, EventPlaceId=1, Address="12 street 67543,downtown", City="seattle",Price=0, Datetime="july 4 10 p.m.", Description="Independence celebration", Name="Fireworks", PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/14"},
                new EventCatalog(){ EventCategoryId=2, EventPlaceId=2, Address="34 street,12345,Calofornia", City="dublin",Price=12, Datetime="Nov 12 -14.", Description="Thanksgiving Drama", Name="Thanksgiving play", PictureUrl="http://externaleventcatalogbaseurltobereplaced/api/EventPic/15"},

            };
        }

        private static IEnumerable<EventCategory> GetPreconfiguredEventCategories()
        {
            return new List<EventCategory>()
            {
                new EventCategory(){Category="Science & Tech"},
                new EventCategory(){Category="Family"},
                new EventCategory(){Category="Arts"}
            };
        }

        private static IEnumerable<EventPlace> GetPreconfiguredEventPlaces()
        {
            return new List<EventPlace>()
            {
                  new EventPlace(){Place="Bellevue"},
                  new EventPlace(){Place="Buffalo"},
                  new EventPlace(){Place="issaquah"}
            };
        }
    }
}
