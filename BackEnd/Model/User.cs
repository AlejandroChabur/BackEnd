using System.ComponentModel.DataAnnotations;
namespace BackEnd.Model
{
    public class User//tabla 
    {
        //Para el manejo de registros se usa context 
        [Key]
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public required string Name { get; set; }//campos de la tabla 
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public required string UserCode { get; set; }

       public int IdUserType { get; set; }
        public UserType UserTypes { get; set; }
      public People Peoples { get; set; }

        public bool IsDelete { get; set; } = false;  // Valor por defecto en falso

    }
}
