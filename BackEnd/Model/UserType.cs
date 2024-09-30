namespace BackEnd.Model
{
    public class UserType
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
