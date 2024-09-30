namespace BackEnd.Model
{
    public class Formats
    {
        public int IdFormats { get; set; }
        public string FormatName { get; set; }
        public ICollection<BooksXFormats> BooksXFormats { get; set; }
    }
}
