namespace BackEnd.Model
{
    public class BooksXEditorials
    {
        public int BookId { get; set; }
        public Books Books { get; set; }

        public int IdEditorials { get; set; }
        public Editorials Editorials { get; set; }

    }
}
