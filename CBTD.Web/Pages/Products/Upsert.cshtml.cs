using CBTD.DataAccess.Models;
using CBTD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CBTD.Web.Pages.Products
{
    public class Upsert : PageModel
    {
 private readonly UnitOfWork _unitOfWork;

        
        [BindProperty]
        public Product ObjProduct { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> ManufacturerList { get; set; }

        public Upsert(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ObjProduct = new Product();
            CategoryList = new List<SelectListItem>();	
            ManufacturerList = new List<SelectListItem>();
           
        }

        public IActionResult OnGet(int? id)
		{
			ObjProduct = new Product();
			CategoryList = _unitOfWork.Category.GetAll()
				.Select(c => new SelectListItem
				{
					Text = c.Name,
					Value = c.Id.ToString()
				}
				);
			ManufacturerList = _unitOfWork.Manufacturer.GetAll()
				.Select(m => new SelectListItem
				{
					Text = m.Name,
					Value = m.Id.ToString()
				}
				);

			if (id == null || id == 0) //create mode
			{
				return Page();
			}

			//edit mode

			if (id != 0)  //retreive product from DB
			{
				ObjProduct = _unitOfWork.Product.GetById(id);
			}

			if (ObjProduct == null) //maybe nothing returned
			{
				return NotFound();
			}

			return Page();

		}

    }
}
