using CBTD.DataAccess.Data;
using CBTD.DataAccess.Models;
using CBTD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages.Categories
{
    public class Delete : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public  Category ObjCategory { get; set; }

 
        public Delete(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ObjCategory = new ();
        }

        public IActionResult OnGet(int? id)
        {
            ObjCategory = new Category();
            if(id != 0)
            {
                ObjCategory = _unitOfWork.Category.GetById(id);
            }
            if(ObjCategory == null)
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

            //if this is a new category
            if (ObjCategory.Id == 0)
            {
                _unitOfWork.Category.Add(ObjCategory);
                TempData["success"] = "Category added Successfully";
            }
            //if category exists
            else
            {
                _unitOfWork.Category.Delete(ObjCategory);
                TempData["success"] = "Category deleted Successfully";
            }
            _unitOfWork.Commit(); 

            return RedirectToPage("./Index");
	    }
    }
}
