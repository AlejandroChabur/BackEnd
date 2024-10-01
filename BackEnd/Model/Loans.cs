using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class Loans
    {
        [Key]
        public int Id { get; set; }
 
        public DateOnly LoanDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        //public ICollection<BooksXLoans> BooksXLoans { get; set; }

        //hksdkaskdjs
    }
}
