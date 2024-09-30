namespace BackEnd.Model
{
    public class Reports
    {
        public int Id { get; set; }
        public virtual required Loans Loans { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
