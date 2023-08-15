using System.Security.Claims;
using CBTD.DataAccess.Models;
using CBTD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages;

public class ProductDetail : PageModel
{
    private readonly UnitOfWork _unitOfWork;
    [BindProperty]
    public int TxtCount { get; set; }
    public ShoppingCart ObjCart { get; set; }
    public Product ObjProduct { get; set; }

    public ProductDetail(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult OnGet(int? productId)
    {
        // Check to see if user logged in
        var claimsIdentity = User.Identity as ClaimsIdentity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        TempData["UserLoggedIn"] = claim;
        ObjProduct = _unitOfWork.Product.Get(p => p.Id == productId, includes: "Category,Manufacturer");
        return Page();
    }
    public IActionResult OnPost(Product objProduct)
    {

        //check to see if we have a shopping cart and this item already for the user

        var claimsIdentity = User.Identity as ClaimsIdentity;

        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

        ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(
            u => u.ApplicationUserId == claim.Value && u.ProductId == objProduct.Id);


        if (cartFromDb == null)
        {
            ObjCart = new ShoppingCart();
            ObjCart.ApplicationUserId = claim.Value;
            ObjCart.ProductId = objProduct.Id;
            ObjCart.Count = TxtCount;
            _unitOfWork.ShoppingCart.Add(ObjCart);
            _unitOfWork.Commit();

        }

        else
        {

            _unitOfWork.ShoppingCart.IncrementCount(cartFromDb, TxtCount);
            _unitOfWork.ShoppingCart.Update(cartFromDb);
            _unitOfWork.Commit();
        }
        return RedirectToPage("Index");
    }
    
}
