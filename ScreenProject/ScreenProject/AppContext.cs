using Microsoft.EntityFrameworkCore;
using ScreenProject.Models;

namespace ScreenProject
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        
        public DbSet<Event> Events { get; set; }
        public DbSet<EventPropereties> EventProps { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateProperties> TemplatesFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // relationship between one event and many event properties 
            modelBuilder.Entity<EventPropereties>(builder =>
            {
                builder.HasOne<Event>(c => c.Events)

                    .WithMany(c => c.EventsProps)
                    .HasForeignKey(c => c.EventId);

            });


            // relationship between one template and many templateFields
            modelBuilder.Entity<TemplateProperties>(builder =>
            {
                builder.HasOne<Template>(c => c.Template)

                    .WithMany(c => c.TemplatesFields)
                    .HasForeignKey(c => c.TemplateId);

            });


            // relationship between one template and many events
            modelBuilder.Entity<Event>(builder =>
            {
                builder.HasOne<Template>(c => c.Templates)

                    .WithMany(c => c.Events)
                    .HasForeignKey(c => c.TemplateId);

            });

            // relationship between one event property one template property 
            modelBuilder.Entity<EventPropereties>(builder =>
            {
                builder.HasOne<TemplateProperties>(c => c.TempFields)

                    .WithOne(c => c.EventPropers)
                    .HasForeignKey<EventPropereties>(c => c.TempfieldId).OnDelete(DeleteBehavior.Restrict);

            });

            base.OnModelCreating(modelBuilder);
        }
        //public DbSet<Car> cars { get; set; }
        //public DbSet<Driver> drivers { get; set; }
    }
}
