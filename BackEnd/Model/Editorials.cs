namespace BackEnd.Model
{
    public class Editorials

    {
        public int IdEditorials{ get; set; }
        public string EditorialsName { get; set; }
        public ICollection<BooksXEditorials> BooksXEditorials { get; set; }

    }
}
    