using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class Reports
    {
        [Key]
        public int Id { get; set; }

        public virtual required Loans Loans { get; set; }
        public string Comment { get; set; }
     
    }
}
