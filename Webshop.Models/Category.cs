using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Models
{
    public class Category
    {
        // Specifying the primary-key id. [Key] is not need as .Net core will already treat it as a primary-key if you write Id or CategoryId.
        [Key]
        public int Id { get; set; }
        // Saying Name is required to be filled out
        [Required]
		[DisplayName("Name")]
		public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100)]
        public  int DisplayOrder { get; set; }
    }
}
