using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class Edition
    {
        [Key]
        public int Id { get; set; }
        public required string EditionName { get; set; }
    }
}
