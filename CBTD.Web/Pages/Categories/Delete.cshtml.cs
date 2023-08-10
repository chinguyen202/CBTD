using CBTD.DataAccess.Data;
using CBTD.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages.Categories
{
    public class Delete : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public  Category ObjCategory { get; set; }

 
        public Delete(ApplicationDbContext db)
        {
            _db = db;
            ObjCategory = new ();
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
                _db.Categories.Remove(ObjCategory);
                TempData["success"] = "Category deleted Successfully";
            }
                _db.SaveChanges();

            return RedirectToPage("./Index");
	    }
    }
}
