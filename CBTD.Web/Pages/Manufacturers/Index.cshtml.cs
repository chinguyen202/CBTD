using CBTD.DataAccess.Data;
using CBTD.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages.Manufacturers
{
    public class Index : PageModel
    {
        private readonly ApplicationDbContext _db;  //local instance of the database service

        public List<Manufacturer> ObjManufacturerList;  //our UI front end will support looping through and displaying Categories retrieved from the database and stored in a List

        public Index(ApplicationDbContext db)  //dependency injection of the database service
        {
                    _db = db; 
        }

        public IActionResult OnGet()
            
        {
            ObjManufacturerList = _db.Manufacturers.ToList();
            return Page();
        }
    }
}
