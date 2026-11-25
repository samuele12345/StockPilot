using Microsoft.EntityFrameworkCore; 
using MyApp1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyApp1.Data
{
    // collega il progetto con il database
    public class MyApp1Context : IdentityDbContext<UserM>
    {
        // Costruttore del contesto: riceve la configurazione del database e la passa a DbContext
        public MyApp1Context(DbContextOptions<MyApp1Context> options) : base(options)
        {

        }

        // metodo di entityframework che ottiene un parametro detto ModelBuilder, utile a definire le configurazioni dei modelli
        // e le relazioni con loro e tra di loro, quindi è un'inizializzazione
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Items>().HasOne(u => u.User).WithMany(it => it.Items).HasForeignKey(uid => uid.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Items>().HasOne(c => c.Category).WithMany(i => i.Items).HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Items>().HasOne(s => s.SerNumber).WithOne(i => i.Item).HasForeignKey<Items>(s => s.SerialId);
        }

        
        public DbSet<Items> Item { get; set; }

        public DbSet<SerialNumber> SerialNumbers { get; set; }

        public DbSet<Category> Categories { get; set; }


    }
}
