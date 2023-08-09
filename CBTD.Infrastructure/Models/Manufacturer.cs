using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CBTD.Infrastructure.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Manufacturer Name")]
        public string Name { get; set; }
    }
}
