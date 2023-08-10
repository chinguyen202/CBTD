using CBTD.DataAccess.Data;
using CBTD.DataAccess.Models;
using CBTD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages.Categories
{
    public class Upsert : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]  //synchonizes form fields with values in code behind
        public Category ObjCategory { get; set; }


        public Upsert(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
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
                _unitOfWork.Category.Update(ObjCategory);
                TempData["success"] = "Category updated Successfully";
            }
            _unitOfWork.Commit();

            return RedirectToPage("./Index");
	    }
    }
}
