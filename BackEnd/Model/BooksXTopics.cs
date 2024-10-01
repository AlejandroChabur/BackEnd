namespace BackEnd.Model
{
    public class BooksXTopics
    {
        public int BooksId { get; set; }  // Clave foránea hacia Books
        public virtual required Books Books { get; set; }

        public int TopicsId { get; set; }  // Clave foránea hacia Topics
        public virtual required Topics Topics { get; set; }
    }
}
