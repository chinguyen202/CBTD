using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CBTD.DataAccess.Models;

namespace CBTD.Web.ViewModels;

public class ShoppingCartVM
{
    public Product Product { get; set; }
    [Range(1,100,ErrorMessage = "Must be between 1 and 1000")]
    public int Count { get; set; }
    public IEnumerable<ShoppingCart> cartItems { get; set; }
    public double CartTotal { get; set; }
}