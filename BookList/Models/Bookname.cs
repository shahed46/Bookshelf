using System.ComponentModel.DataAnnotations;

namespace BookList.Models
{
    public class Bookname
    {
        [key]
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }


}

