namespace BackEnd.Model
{
    public class Books///gg
    {
        public int Id { get; set; }
        public virtual required Edition Edition { get; set; }
        public required string Title { get; set; }
        public required string Code { get; set; }

        public DateOnly PublicationYear {  get; set; }

    }
}
