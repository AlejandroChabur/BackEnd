namespace BackEnd.Model
{
    public class BooksXAuthors
    {
        public int BookId { get; set; }
        public Books Books { get; set; }

        public int IdPersona { get; set; }
        public People People { get; set; }
        public object IdPeople { get; internal set; }
    }
}
