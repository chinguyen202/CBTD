using CBTD.DataAccess.Data;
using CBTD.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages.Manufacturers
{
    public class Delete : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]  //synchonizes form fields with values in code behind
        public Manufacturer ObjManufacturer { get; set; }


        public Delete(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int? id)
        {
            ObjManufacturer = new Manufacturer();
            if(id != 0)
            {
                ObjManufacturer = _db.Manufacturers.Find(id);
            }
            if(ObjManufacturer == null)
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

            //if this is a new Manufacturer
            if (ObjManufacturer.Id == 0)
            {
                _db.Manufacturers.Add(ObjManufacturer);
                TempData["success"] = "Manufacturer added Successfully";
            }
            //if Manufacturer exists
            else
            {
                _db.Manufacturers.Remove(ObjManufacturer);
                TempData["success"] = "Manufacturer deleted Successfully";
            }
                _db.SaveChanges();

            return RedirectToPage("./Index");
	    }
    }
}
