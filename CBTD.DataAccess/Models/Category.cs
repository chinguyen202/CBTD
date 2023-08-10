using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CBTD.DataAccess.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order must be between 1 and 100 only.")]
        public int DisplayOrder { get; set; }
    }
}
