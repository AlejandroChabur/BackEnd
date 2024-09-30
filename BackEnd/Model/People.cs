namespace BackEnd.Model
{
    public class People
    {

        public int Id { get; set; }
        public virtual required IdentificationType IdentificationType { get; set; }
        public required string IdentificationNumber { get; set; }

        public required string FirstName { get; set; }
        public required string MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string SecondLastName { get; set; }
       

        public required string Address { get; set; }

        public required DateOnly borndate { get; set; }




    }
}
