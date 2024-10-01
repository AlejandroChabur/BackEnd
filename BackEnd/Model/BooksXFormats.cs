namespace BackEnd.Model
{
    public class BooksXFormats
    {
        public virtual required Books Books { get; set; }
        public virtual required Formats Formats { get; set; }
    }
}
