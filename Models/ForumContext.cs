using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebForum.Models
{
    public class ForumContext : IdentityDbContext<User, Role, Guid>
    {
        // Category --> Sections --> Themes --> Messages
        // 1 to Many___Many to Many___1 to Many
        public DbSet<Message> Messages { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<ThemeSection> ThemeSections { get; set; } //it`s helping table for connection Many to Many
        public DbSet<Section> Sections { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Report> Reports { get; set; }

        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {
            // Database.EnsureDeleted();   //DANGEROUS!!! Delete old data from database!
            // Database.EnsureCreated();   // Create new database
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>(m =>
            {
                m.HasOne(m => m.Theme)
                .WithMany(t => t.Messages)
                .OnDelete(DeleteBehavior.Cascade); //If Theme deleted, all messages delete too

                m.HasOne(m => m.Author)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull); //If Author delete - message author became null

                m.Property("CreatingTime").HasDefaultValueSql("GETDATE()");
            });

            builder.Entity<Theme>(t =>
            {
                t.HasMany(t => t.Messages)
                .WithOne(m => m.Theme);

                t.HasOne(m => m.Author)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull); // If Author delete - theme author became null

                t.Property("CreatingTime").HasDefaultValueSql("GETDATE()");
            });

            builder.Entity<User>(u =>
            {
            u.HasMany(u => u.Messages)
            .WithOne(m => m.Author)
            .OnDelete(DeleteBehavior.NoAction); //If message deleted - nothing happens with User

            u.HasMany(u => u.Themes)
            .WithOne(t => t.Author)
            .OnDelete(DeleteBehavior.NoAction); // If theme deleted - nothing happens with User

            u.Property("RegistrationDate").HasDefaultValue("GETDATE()");

            });

            // MANY to MANY connection with helping class ThemeSection (table ThemeSections)
            // with Theme and Section
            builder.Entity<ThemeSection>(ts =>
            {
                ts.HasOne(ts => ts.Theme)
                .WithMany(ts => ts.Sections)
                .OnDelete(DeleteBehavior.Cascade); // If theme deleted - helping connections in ThemeSection delete too

                ts.HasOne(ts => ts.Section)
                .WithMany(ts => ts.Themes)
                .OnDelete(DeleteBehavior.Cascade); // If section(topic) deleted - helping connections in ThemeSection delete too
            });

            builder.Entity<Category>()
                .HasMany(c => c.Sections)
                .WithOne(s => s.Category)
                .OnDelete(DeleteBehavior.SetNull); // If section deleted - sectionId in Category set NULL

            builder.Entity<Report>(r =>
            {
                r.HasOne(r => r.Sender)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull); // If report sender deleted - report don`t deleted, sender value became NULL

                r.Property("SendingTime").HasDefaultValueSql("GETDATE()");
            });

            base.OnModelCreating(builder);
        }
    }
}
