namespace BackEnd.Model
{
    public class BooksXAuthors
    {
        public int BooksId { get; set; }  // Clave foránea hacia Books
        public virtual required Books Books { get; set; }

        public int AuthorsId{ get; set; }  // Clave foránea hacia Editorials
        public virtual required Authors Authors { get; set; }
    }
}
