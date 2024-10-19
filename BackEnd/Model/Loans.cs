using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class Loans
    {
        [Key]
        public int Id { get; set; }
        public int IdUser { get; set; }
 
        public DateOnly LoanDate { get; set; }
        public DateOnly ReturnDate { get; set; }
       public User User { get; set; }

        public bool IsDelete { get; set; } = false;  // Valor por defecto en falso
    }
}
