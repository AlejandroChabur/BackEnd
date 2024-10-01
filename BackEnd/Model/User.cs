using System.ComponentModel.DataAnnotations;
namespace BackEnd.Model
{
    public class User//tabla 
    {
        //Para el manejo de registros se usa context 
        [Key]
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public required string Name { get; set; }//campos de la tabla 
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public required string UserCode { get; set; }

        public virtual required UserType UserType { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
