using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookAuthorM2MApp.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required, StringLength(256)]
        public string? Title { get; set; }
        public int PublicationYear { get; set; }
        [DisplayName("Number of Authors")]
        public ICollection<Author?> Authors { get; set; } = new List<Author?>();    
    }
}
