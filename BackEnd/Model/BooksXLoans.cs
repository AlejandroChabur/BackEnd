namespace BackEnd.Model
{
    public class BooksXLoans
    {
        public virtual required Books Books { get; set; }
        public virtual required Loans Loans { get; set; }
    }
}
