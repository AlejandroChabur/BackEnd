

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
        public DbSet<UserType> UserType { get; set; }
       
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
       // public DbSet<AuthorsXBooks>authorsXBooks { get; set; }
        public DbSet<BooksXEditorials> BooksXEditorials { get; set; }
        public DbSet<BooksXFormats> BooksXFormats { get; set; }
        public DbSet<BooksXLoans> BooksXLoans { get; set; }
        public DbSet<BooksXTopics> BooksXTopics { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
           .HasOne(a => a.Peoples) // Propiedad de navegación en Authors
           .WithMany() // No necesitas una propiedad de navegación inversa en People si no la tienes
           .HasForeignKey(a => a.IdPerson) // Clave foránea que apunta a Id en People
           .OnDelete(DeleteBehavior.Restrict); // Comportamien

            //////////////////////
            modelBuilder.Entity<User>()
          .HasOne<UserType>(a => a.UserTypes) // Propiedad de navegación en Authors
          .WithMany() // No necesitas una propiedad de navegación inversa en People si no la tienes
          .HasForeignKey(a => a.IdUserType) // Clave foránea que apunta a Id en People
          .OnDelete(DeleteBehavior.Restrict); // Comportamien
            /////////////////
             modelBuilder.Entity<Books>()
          .HasOne<Edition>(a => a.Edition) // Propiedad de navegación en Authors
          .WithMany() // No necesitas una propiedad de navegación inversa en People si no la tienes
          .HasForeignKey(a => a.IdEdition) // Clave foránea que apunta a Id en People
          .OnDelete(DeleteBehavior.Restrict); // Comportamien

            ///////////////
            modelBuilder.Entity<Loans>()
           .HasOne<User>(a => a.User) // Propiedad de navegación en Authors
           .WithMany() // No necesitas una propiedad de navegación inversa en People si no la tienes
           .HasForeignKey(a => a.IdUser) // Clave foránea que apunta a Id en People
           .OnDelete(DeleteBehavior.Restrict); // Comportamien>>>>>

            modelBuilder.Entity<Reports>()
         .HasOne<Loans>(a => a.Loans) // Propiedad de navegación en Authors
         .WithMany() // No necesitas una propiedad de navegación inversa en People si no la tienes
         .HasForeignKey(a => a.IdLoan) // Clave foránea que apunta a Id en People
         .OnDelete(DeleteBehavior.Restrict); // Comportamien>>>>





            modelBuilder.Entity<Authors>()
         .HasOne(a => a.Person) // Propiedad de navegación en Authors
         .WithMany() // No necesitas una propiedad de navegación inversa en People si no la tienes
         .HasForeignKey(a => a.IdPerson) // Clave foránea que apunta a Id en People
         .OnDelete(DeleteBehavior.Restrict); // Comportamien

            modelBuilder.Entity<People>()
   .HasOne<IdentificationType>(a => a.IdentificationTypes) // Asumiendo que tienes una propiedad Person en Authors
   .WithMany() // Si People no tiene relación inversa, puedes dejarlo así
   .HasForeignKey(a => a.IdIdentificationType) // Cambia IdPersona por el nombre de la clave foránea
   .OnDelete(DeleteBehavior.Restrict); // Esto evitará ciclos o múltiples rutas en casca


            modelBuilder.Entity<BooksXAuthors>()
            .HasNoKey();
            modelBuilder.Entity<BooksXTopics>()
             .HasNoKey();
            modelBuilder.Entity<BooksXLoans>()
             .HasNoKey();
            modelBuilder.Entity<BooksXFormats>()
             .HasNoKey();
            modelBuilder.Entity<BooksXEditorials>()
             .HasNoKey();
            





        }


    }
}
