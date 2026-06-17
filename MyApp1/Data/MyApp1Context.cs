using Microsoft.EntityFrameworkCore; // utile per importare il framework per lavorare sui db
using MyApp1.Models;

namespace MyApp1.Data
{
    // collega il progetto con il database
    public class MyApp1Context : DbContext // estende DbContext
    {
        // Costruttore del contesto: riceve la configurazione del database e la passa a DbContext
        public MyApp1Context(DbContextOptions<MyApp1Context> options) : base(options)
        {

        }

        // metodo di entityframework che ottiene un parametro detto ModelBuilder, utile a definire le configurazioni dei modelli
        // e le relazioni con loro e tra di loro, quindi è un'inizializzazione
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura la chiave primaria composta della tabella ponte: una riga è identificata dalla coppia ItemId + ClientId.
            modelBuilder.Entity<ItemsClient>().HasKey(ic => new
            {
                ic.ItemId,
                ic.ClientId
            });


            // Configura la relazione molti-a-molti tramite ItemsClient:
            // un Item può comparire in più record ItemsClient e un Client può comparire in più record ItemsClient.
            modelBuilder.Entity<ItemsClient>().HasOne(i => i.Item).WithMany(ic => ic.ItemsClient).HasForeignKey(i => i.ItemId);
            modelBuilder.Entity<ItemsClient>().HasOne(c => c.Client).WithMany(ic => ic.ItemsClient).HasForeignKey(c => c.ClientId);

            // eseguire Add-Migration "..." e  Update - Database per applicare le modifiche
            // HasData definisce dati iniziali gestiti da migration: se usi lo stesso Id, EF Core tratta il record come seed da aggiornare con i nuovi valori.
            // inizializzazione di un item di tipo Items
            modelBuilder.Entity<Items>().HasData(
                    new Items { Id = 4, Name = "Microphone", Price = 40, IdSerial = 10 }
                );

            // inizializzazione di un item di tipo SerialNumber
            modelBuilder.Entity<SerialNumber>().HasData(
                    new SerialNumber { Id = 10, Name = "MIC150" }
                );

            modelBuilder.Entity<Category>().HasData(
                    // a differenza di id e name, items viene settato tramite action
                    new Category { id = 1, Name = "Electronics" },
                    new Category { id = 2, Name = "Books" }
                );

            base.OnModelCreating(modelBuilder);
        }

        // Rappresenta la tabella Items nel database e permette di leggere/salvare oggetti Items
        public DbSet<Items> Item { get; set; }

        public DbSet<SerialNumber> SerialNumbers { get; set; }

        public virtual DbSet<Persone> Persones { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ItemsClient> ItemsClient { get; set; }
    }
}
