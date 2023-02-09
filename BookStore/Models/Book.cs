namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsBooked { get; set; }
        public int BookedByPersonId { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
