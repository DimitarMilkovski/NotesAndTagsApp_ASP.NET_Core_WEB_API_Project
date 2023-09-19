using Microsoft.EntityFrameworkCore;
using NotesAndTagsApp.Domain.Models;

namespace NotesAndTagsApp.DataAccess
{
    public class NotesAndTagsAppDbContext : DbContext
    {
        public NotesAndTagsAppDbContext(DbContextOptions options) : base(options) { }   

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Note>()
                .Property(x => x.Text)
                .HasMaxLength(100)
                .IsRequired(); 

            modelBuilder.Entity<Note>()
                .Property(x => x.Priority)
                .IsRequired();

            modelBuilder.Entity<Note>()
               .Property(x => x.Tag)
               .IsRequired();

            
            modelBuilder.Entity<Note>()
                .HasOne(x => x.User)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.UserId);

           
            modelBuilder.Entity<User>()
                .Property(x => x.Firstname)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(x => x.Lastname)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(x => x.Username)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Ignore(x => x.Age); 
        }
    }
}