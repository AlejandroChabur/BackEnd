namespace BackEnd.Model
{
    public class BooksXLoans
    {
        public int BooksId { get; set; }  // Clave foránea hacia Books
        public virtual required Books Books { get; set; }

        public int LoansId { get; set; }  // Clave foránea hacia Loans
        public virtual required Loans Loans { get; set; }
    }
}