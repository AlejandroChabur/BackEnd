namespace BackEnd.Model
{
    public class Authors : People
    {
        public required string Country { get; set; }
        public int Id { get; internal set; }
    }
}
