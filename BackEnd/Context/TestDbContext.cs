using BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Context
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) :base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<IdentificationType> IdentificationTypes { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Topics> Topics { get; set; }
        public DbSet<Editorials> Editorials { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Formats> Formats { get; set; }
        public DbSet<BooksXTopics> BooksXTopics { get; set; }
        public object BooksXAuthors { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad User
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            // Configuración de la relación entre User y People
            modelBuilder.Entity<User>()
                .HasOne<People>()
                .WithMany()
                .HasForeignKey(u => u.IdPersona); // Relaciona IdPersona de User con Id de People

            // Configuración de la entidad People
            modelBuilder.Entity<People>()
                .ToTable("People"); // Especifica la tabla para People

            // Configuración de la herencia entre People y Authors
            modelBuilder.Entity<Authors>()
                .ToTable("Authors")
                .HasBaseType<People>();

            modelBuilder.Entity<Authors>()
                .Property(a => a.Country)
                .IsRequired();

            // Configuración de BooksXAuthors
            modelBuilder.Entity<BooksXAuthors>()
                .HasKey(ba => new { ba.BookId, ba.IdPersona });  // Clave compuesta

            modelBuilder.Entity<BooksXAuthors>()
                .HasOne(ba => ba.Books)
                .WithMany(b => b.BooksXAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BooksXAuthors>()
                .HasOne(ba => ba.People)
                .WithMany() // Se puede especificar la colección si tienes una propiedad de navegación en People
                .HasForeignKey(ba => ba.IdPersona);

            modelBuilder.Entity<BooksXTopics>()
            .HasKey(ab => new { ab.BookId, ab.TopicId });  // Clave compuesta

            modelBuilder.Entity<BooksXTopics>()
                .HasOne(ab => ab.Books)
                .WithMany(a => a.BooksXTopics)
                .HasForeignKey(ab => ab.BookId);

            modelBuilder.Entity<BooksXTopics>()
                .HasOne(ab => ab.Topics)
                .WithMany(b => b.BooksXTopics)
                .HasForeignKey(ab => ab.TopicId);

            modelBuilder.Entity<BooksXAuthors>()
            .HasKey(ab => new { ab.BookId, ab.IdPeople });  // Clave compuesta

            modelBuilder.Entity<BooksXAuthors>()
                .HasOne(ab => ab.Books)
                .WithMany(a => a.BooksXAuthors)
                .HasForeignKey(ab => ab.BookId);

            modelBuilder.Entity<BooksXAuthors>()
                .HasOne(ab => ab.People)
                .WithMany(b => b.BooksXAuthors)
                .HasForeignKey(ab => ab.IdPeople);

            modelBuilder.Entity<BooksXLoans>()
           .HasKey(ab => new { ab.BookId, ab.IdLoans });  // Clave compuesta

            modelBuilder.Entity<BooksXLoans>()
                .HasOne(ab => ab.Books)
                .WithMany(a => a.BooksXLoans)
                .HasForeignKey(ab => ab.BookId);

            modelBuilder.Entity<BooksXLoans>()
                .HasOne(ab => ab.Loans)
                .WithMany(b => b.BooksXLoans)
                .HasForeignKey(ab => ab.IdLoans);

            modelBuilder.Entity<BooksXEditorials>()
           .HasKey(ab => new { ab.BookId, ab.IdEditorials });  // Clave compuesta

            modelBuilder.Entity<BooksXEditorials>()
                .HasOne(ab => ab.Books)
                .WithMany(a => a.BooksXEditorials)
                .HasForeignKey(ab => ab.BookId);

            modelBuilder.Entity<BooksXEditorials>()
                .HasOne(ab => ab.Editorials)
                .WithMany(b => b.BooksXEditorials)
                .HasForeignKey(ab => ab.IdEditorials);

            modelBuilder.Entity<BooksXFormats>()
          .HasKey(ab => new { ab.BookId, ab.IdFormats });  // Clave compuesta

            modelBuilder.Entity<BooksXFormats>()
                .HasOne(ab => ab.Books)
                .WithMany(a => a.BooksXFormats)
                .HasForeignKey(ab => ab.BookId);

            modelBuilder.Entity<BooksXFormats>()
                .HasOne(ab => ab.Formats)
                .WithMany(b => b.BooksXFormats)
                .HasForeignKey(ab => ab.IdFormats);





        }


    }
}
