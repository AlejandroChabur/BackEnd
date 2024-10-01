using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
   
        public class Authors
        {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public required string Country { get; set; }
        public bool IsDeleted { get; internal set; }
    } 
}
