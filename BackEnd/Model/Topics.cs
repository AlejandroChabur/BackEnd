using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class Topics
    {
        [Key]
        public int Id { get; set; }
        public string TopicName { get; set; }
        //public ICollection<BooksXTopics> BooksXTopics { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
