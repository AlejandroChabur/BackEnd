namespace BackEnd.Model
{
    public class Books
    {
        public int BookId { get; set; }
        public int EditionId { get; set; }
        public virtual required Edition Edition { get; set; }
        public required string Title  { get; set; }
        public required string Code { get; set; }
        public required string secondcode { get; set; }

        public DateOnly PublicationYear {  get; set; }
        public ICollection<BooksXTopics> BooksXTopics { get; set; }
        public ICollection<BooksXAuthors> BooksXAuthors { get; set; }
        public ICollection<BooksXLoans> BooksXLoans { get; set; }
        public ICollection<BooksXEditorials> BooksXEditorials { get; set; }
        public ICollection<BooksXFormats> BooksXFormats { get; set; }

    }
}
//ddd