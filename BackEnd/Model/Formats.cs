using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class Formats
    {
        [Key]
        public int Id { get; set; }
        public required string FormatName { get; set; }
        //public required ICollection<BooksXFormats> BooksXFormats { get; set; }
        public bool IsDelete { get; set; } = false;  // Valor por defecto en falso


    }
}
