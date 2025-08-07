namespace bookapi_minimal.Models
{
    public class BookModel
    {
        public Guid Id { set; get; }
        public String? Title { set; get; }
        public String? Author { set; get; }
        public String? Description { set; get; }
        public String? Category { set; get; }
        public String? Language { set; get; }
        public int TotalPages { set; get; }

    }
}