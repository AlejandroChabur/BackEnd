namespace BackEnd.Model
{
    public class BooksXTopics
    {
        public virtual required Books Books { get; set; }
        public virtual required Topics Topics { get; set; }
    }
}
