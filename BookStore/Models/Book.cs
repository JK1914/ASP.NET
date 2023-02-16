namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublisherDate { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public  int Refund { get; set; }
        public  int inStore { get; set; }
        public bool IsBooked { get; set; }
        public User BookedBy { get; set; }
    }
}
