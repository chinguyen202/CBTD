using CBTD.DataAccess.Models;
using CBTD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages;

public class ProductDetail : PageModel
{
    private readonly UnitOfWork _unitOfWork;
    [BindProperty]
    public int txtCount { get; set; }

    public Product objProduct { get; set; }

    public ProductDetail(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult OnGet(int? productId)
    {
        objProduct = _unitOfWork.Product.Get(p => p.Id == productId, includes: "Category,Manufacturer");
        return Page();
    }

}