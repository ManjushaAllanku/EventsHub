using EventCatalaogApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalaogApi.Data
{
    public class EventCatalogContext:DbContext
    {
        public EventCatalogContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<EventCategory> EventCategories { get; set; }

        public DbSet<EventPlace> EventPlaces { get; set; }

        public DbSet<EventCatalog> EventCatalogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>(ConfigureEventCategory);
            modelBuilder.Entity<EventPlace>(ConfigureEventPlace);
            modelBuilder.Entity<EventCatalog>(ConfigureEventCatalog);

        }

       

        private void ConfigureEventCatalog(EntityTypeBuilder<EventCatalog> builder)
        {
            builder.ToTable("EventCatalog");
            builder.Property(E => E.Id).IsRequired().ForSqlServerUseSequenceHiLo("event_catalog_hilo");
            builder.Property(E => E.Name).IsRequired().HasMaxLength(50);
            builder.Property(E => E.Address).IsRequired().HasMaxLength(100);
            builder.Property(E => E.City).IsRequired().HasMaxLength(50);
            builder.Property(E => E.Price).IsRequired();
            builder.Property(E => E.PictureUrl).IsRequired();
            builder.Property(E => E.Datetime).IsRequired().HasMaxLength(50);

            builder.HasOne(E => E.EventCategory).WithMany().HasForeignKey(E => E.EventCategoryId);
            builder.HasOne(E => E.EventPlace).WithMany().HasForeignKey(E => E.EventPlaceId);

        }

        private void ConfigureEventPlace(EntityTypeBuilder<EventPlace> builder)
        {
            builder.ToTable("EventPlaces");
            builder.Property(E => E.Id).IsRequired()
                                      .ForSqlServerUseSequenceHiLo("event_place_hilo");
            builder.Property(E => E.Place).IsRequired().HasMaxLength(100);
            
        }

        private void ConfigureEventCategory(EntityTypeBuilder<EventCategory> builder)
        {
          builder.ToTable("EventCategories");
          builder.Property(E => E.Id).IsRequired().ForSqlServerUseSequenceHiLo("event_category_hilo");
          builder.Property(E => E.Category).IsRequired().HasMaxLength(100);



        }
    }
}
