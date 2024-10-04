using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class Reports
    {
        [Key]
        public int Id { get; set; }

       public int IdLoan { get; set; }
        public string Comment { get; set; }

        public Loans Loans { get; set; }    
     
    }
}
