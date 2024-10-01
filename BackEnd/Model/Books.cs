using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class Books
    {
        [Key]
        public  int Id { get; set; }
        public int EditionId { get; set; }
        public virtual required Edition Edition { get; set; }
        public required string Title  { get; set; }
        public required string Code { get; set; }


        public DateOnly PublicationYear {  get; set; }
        public virtual ICollection<Authors> Authors { get; set; } = new List<Authors>();

    }
}
//ddd