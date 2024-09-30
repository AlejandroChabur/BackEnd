namespace BackEnd.Model
{
    public class Topics
    {
        public int IdTopic { get; set; }
        public string TopicName { get; set; }
        public ICollection<BooksXTopics> BooksXTopics { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
