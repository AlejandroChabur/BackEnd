namespace BackEnd.Model
{
    public class BooksXTopics
    {
        public int BookId { get; set; }
        public Books Books { get; set; }

        public int TopicId { get; set; }
        public Topics Topics { get; set; }
    }
}
