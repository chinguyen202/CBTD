using CBTD.DataAccess.Models;
using CBTD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CBTD.Web.Pages.Products;

public class Upsert : PageModel
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

        
    [BindProperty]
    public Product ObjProduct { get; set; }

    public IEnumerable<SelectListItem> CategoryList { get; set; }
    public IEnumerable<SelectListItem> ManufacturerList { get; set; }

    public Upsert(UnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
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
    
    public IActionResult OnPost(int? id)
		{
			string webRootPath = _webHostEnvironment.WebRootPath;
			var files = HttpContext.Request.Form.Files;

			//if the product is new (create)

			if (ObjProduct.Id == 0)
			{
				//was there even an image uploaded?

				if (files.Count > 0)
				{
					//create a unique identifier for image name
					string fileName = Guid.NewGuid().ToString();

					//create variable to hold a path to images\products
					var uploads = Path.Combine(webRootPath, @"images\products\");

					//get and preserve the extension type 

					var extension = Path.GetExtension(files[0].FileName);

					// create the full upload path 

					var fullPath = uploads + fileName + extension;

					//stream the binary write to the server

					using var fileStream = System.IO.File.Create(fullPath);
					files[0].CopyTo(fileStream);

					//associate the actual URL path and save to DB URLImage

					ObjProduct.ImageUrl = @"\images\products\" + fileName + extension;
				}
				//add this new Product internal model

				_unitOfWork.Product.Add(ObjProduct);

			}

			//the item exists, so we're updating it

			else
			{
				//get the product again from the DB because
				//binding is on, and we need to process the
				//physical image separately from the binded
				//property holding URL string

				var objProductFromDb = _unitOfWork.Product.Get(p => p.Id == ObjProduct.Id);
				//was there even an image uploaded?

				if (files.Count > 0)
				{
					//create a unique identifier for image name
					string fileName = Guid.NewGuid().ToString();

					//create variable to hold a path to images\products
					var uploads = Path.Combine(webRootPath, @"images\products\");

					//get and preserve the extension type 

					var extension = Path.GetExtension(files[0].FileName);

					//if the product stored in DB has image path

					if (objProductFromDb.ImageUrl != null)
					{
						var imagePath =
							Path.Combine(webRootPath, ObjProduct.ImageUrl.TrimStart('\\'));

						//if the image exists physically

						if (System.IO.File.Exists(imagePath))
						{
							System.IO.File.Delete(imagePath);
						}
					}

					// create the full upload path 

					var fullPath = uploads + fileName + extension;

					//stream the binary write to the server

					using var fileStream = System.IO.File.Create(fullPath);
					files[0].CopyTo(fileStream);

					//associate the actual URL path and save to DB URLImage

					ObjProduct.ImageUrl = @"\images\products\" + fileName + extension;
				}
				else
				{
					//we're trying to add image for 1st time
					//to to the product we are updating
					objProductFromDb.ImageUrl = ObjProduct.ImageUrl;
				}
				//update the existing product
				_unitOfWork.Product.Update(ObjProduct);
			}
			//Save Changes to Database
			_unitOfWork.Commit();

			//redirect to the Products Page
			return RedirectToPage("./Index");
		}


}