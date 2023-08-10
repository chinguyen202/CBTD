using CBTD.DataAccess.Models;
using CBTD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages.Products
{
    public class Index : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        public IEnumerable<Product> ObjProductList;
        public Index(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ObjProductList = new List<Product>();
        }

        public IActionResult OnGet()
        {
            ObjProductList = _unitOfWork.Product.GetAll();
            return Page();
        }
    }
}
