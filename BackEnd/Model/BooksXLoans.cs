namespace BackEnd.Model
{
    public class BooksXLoans
    {
        public int BookId { get; set; }
        public Books Books { get; set; }

        public int IdLoans { get; set; }
        public Loans Loans { get; set; }
    }
}
