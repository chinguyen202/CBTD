using CBTD.DataAccess.Models;
using CBTD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages;

public class IndexModel : PageModel
{
    public IEnumerable<Product> objProductList;
    public IEnumerable<Category> objCategoryList { get; set; }
    private readonly UnitOfWork _unitOfWork;

    public IndexModel(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult OnGet()
    {
        objCategoryList = _unitOfWork.Category.GetAll(null, c => c.DisplayOrder, null);
        objProductList = _unitOfWork.Product.GetAll(null, includes: "Category,Manufacturer");
        return Page();
    }
}


