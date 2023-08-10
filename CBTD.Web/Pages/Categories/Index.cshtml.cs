using CBTD.DataAccess.Data;
using CBTD.DataAccess.Models;
using CBTD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages.Categories
{
    public class Index : PageModel
    {
        // private readonly ApplicationDbContext _db;  //local instance of the database service
        // public List<Category> objCategoryList;  //our UI front end will support looping through and displaying Categories retrieved from the database and stored in a List
        // public Index(ApplicationDbContext db)  //dependency injection of the database service
        // {
        //             _db = db; 
        // }
        private readonly UnitOfWork _unitOfWork;
        public IEnumerable<Category> ObjCategoryList;
        public Index(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ObjCategoryList = new List<Category>();
        }

        public IActionResult OnGet()
        {
            ObjCategoryList = _unitOfWork.Category.GetAll();
            return Page();
        }

    }
}
