namespace BackEnd.Model
{
    public class BooksXFormats
    {
        public int BooksId { get; set; }  // Clave foránea hacia Books
        public virtual required Books Books { get; set; }

        public int FormatsId { get; set; }  // Clave foránea hacia Formats
        public virtual required Formats Formats { get; set; }
    }
}
