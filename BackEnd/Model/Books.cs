using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class Books
    {
        [Key]
        
        public int Id { get; set; }  // Cambié BookId a Id para consistencia
        public int EditionId { get; set; }
        public virtual required Edition Edition { get; set; }

        public required string Title { get; set; }
        public required string Code { get; set; }

        public DateOnly PublicationYear {  get; set; }

       
    }
}
//ddd