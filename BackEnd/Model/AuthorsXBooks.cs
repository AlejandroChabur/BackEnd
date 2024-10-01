namespace BackEnd.Model
{
    public class AuthorsXBooks
    {
        public int BooksId { get; set; }  // Debe coincidir con Books.Id
        public int AuthorsId { get; set; } // Debe coincidir con Authors.Id
        public virtual required Books Books { get; set; }
        public virtual required Authors Authors { get; set; }
    }
}
