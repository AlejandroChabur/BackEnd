namespace BackEnd.Model
{
    public class Loans
    {
        public int Id { get; set; }
        public virtual required User User { get; set; }
        public DateOnly LoanDate { get; set; }
        public DateOnly ReturnDate { get; set; }

    }
}
