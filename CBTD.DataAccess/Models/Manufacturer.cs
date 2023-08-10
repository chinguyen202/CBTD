using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CBTD.DataAccess.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Manufacturer Name")]
        public string Name { get; set; }
    }
}
