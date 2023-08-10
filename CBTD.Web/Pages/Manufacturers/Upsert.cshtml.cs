using CBTD.DataAccess.Data;
using CBTD.DataAccess.Models;
using CBTD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages.Manufacturers
{
    public class Upsert : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]  //synchonizes form fields with values in code behind
        public Manufacturer ObjManufacturer { get; set; }


        public Upsert(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet(int? id)
        {
            ObjManufacturer = new Manufacturer();
            if(id != 0)
            {
                ObjManufacturer = _unitOfWork.Manufacturer.GetById(id); 
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
                _unitOfWork.Manufacturer.Add(ObjManufacturer);
                TempData["success"] = "Manufacturer added Successfully";
            }
            //if Manufacturer exists
            else
            {
                _unitOfWork.Manufacturer.Update(ObjManufacturer);
                TempData["success"] = "Manufacturer updated Successfully";
            }
                _unitOfWork.Commit();

            return RedirectToPage("./Index");
	    }
    }
}
