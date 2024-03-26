using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        // Specifying the primary-key id. [Key] is not need as .Net core will already treat it as a primary-key if you write Id or CategoryId.
        [Key]
        public int Id { get; set; }
        // Saying Name is required to be filled out
        [Required]
        public string Name { get; set; }
        public  int DisplayOrder { get; set; }
    }
}
