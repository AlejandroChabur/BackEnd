namespace BackEnd.Model
{
    public class BooksXEditorials
    {
        public int BooksId { get; set; }  // Clave foránea hacia Books
        public virtual required Books Books { get; set; }

        public int EditorialsId { get; set; }  // Clave foránea hacia Editorials
        public virtual required Editorials Editorials { get; set; }
    }
}

