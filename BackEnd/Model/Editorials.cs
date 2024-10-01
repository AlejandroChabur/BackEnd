using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class Editorials

    {
        [Key]
        public int Id { get; set; }
        public string EditorialsName { get; set; }
      

    }
}
