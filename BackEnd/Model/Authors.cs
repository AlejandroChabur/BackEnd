using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
   
        public class Authors
        {
        public int Id { get; set; }
        
        public int IdPerson{ get; set; }

        public required string Country { get; set; }
        public People Person { get; set; }

        public bool IsDelete { get; set; } = false;  // Valor por defecto en falso



    }
}
