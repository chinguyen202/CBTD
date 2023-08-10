using CBTD.DataAccess.Data;
using CBTD.DataAccess.Models;
using CBTD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages.Manufacturers
{
    public class Index : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        public IEnumerable<Manufacturer> ObjManufacturerList;
        public Index(UnitOfWork unitOfWork)  //dependency injection of the database service
        {
            _unitOfWork = unitOfWork;
            ObjManufacturerList = new List<Manufacturer>();
        }

        public IActionResult OnGet()
            
        {
            ObjManufacturerList = _unitOfWork.Manufacturer.GetAll();
            return Page();
        }
    }
}
