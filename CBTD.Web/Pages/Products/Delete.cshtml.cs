using CBTD.DataAccess.Models;
using CBTD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages.Products
{
    public class Delete : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public  Product ObjProduct { get; set; }

 
        public Delete(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ObjProduct = new ();
        }

        public IActionResult OnGet(int? id)
        {
            ObjProduct = new Product();
            if(id != 0)
            {
                ObjProduct = _unitOfWork.Product.GetById(id);
            }
            if(ObjProduct == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //if this is a new Product
            if (ObjProduct.Id == 0)
            {
                _unitOfWork.Product.Add(ObjProduct);
                TempData["success"] = "Product added Successfully";
            }
            //if Product exists
            else
            {
                _unitOfWork.Product.Delete(ObjProduct);
                TempData["success"] = "Product deleted Successfully";
            }
            _unitOfWork.Commit(); 

            return RedirectToPage("./Index");
	    }
    }
}