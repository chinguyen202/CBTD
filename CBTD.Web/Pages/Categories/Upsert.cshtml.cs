using CBTD.DataAccess.Data;
using CBTD.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages.Categories
{
    public class Upsert : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]  //synchonizes form fields with values in code behind
        public Category ObjCategory { get; set; }


        public Upsert(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int? id)
        {
            ObjCategory = new Category();
            if(id != 0)
            {
                ObjCategory = _db.Categories.Find(id);
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
                _db.Categories.Add(ObjCategory);
                TempData["success"] = "Category added Successfully";
            }
            //if category exists
            else
            {
                _db.Categories.Update(ObjCategory);
                TempData["success"] = "Category updated Successfully";
            }
                _db.SaveChanges();

            return RedirectToPage("./Index");
	    }


    }
}
