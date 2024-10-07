using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class Books
    {
        [Key]
        
        public int Id { get; set; }  // Cambié BookId a Id para consistencia
        public int IdEdition { get; set; }
       

        public required string Title { get; set; }
        public required string Code { get; set; }

        public DateOnly PublicationYear {  get; set; }

        public Edition Edition { get; set; }

        public bool IsDelete { get; set; } = false;  // Valor por defecto en falso



    }
}
//ddd//ya funcionapor fin