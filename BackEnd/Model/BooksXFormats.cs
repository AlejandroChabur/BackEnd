namespace BackEnd.Model
{
    public class BooksXFormats
    {
        public int BookId { get; set; }
        public Books Books { get; set; }

        public int IdFormats { get; set; }
        public Formats Formats   { get; set; }
    }
}
