using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
