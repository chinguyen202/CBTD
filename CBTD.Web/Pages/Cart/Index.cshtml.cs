using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using CBTD.Infrastructure;
using CBTD.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages.Cart;

public class Index : PageModel
{
    private readonly UnitOfWork _unitOfWork;
      
    public ShoppingCartVM ShoppingCartVm { get; set; }
    public Index(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult OnGet()
    {
        var claimsIdentity = User.Identity as ClaimsIdentity;
        
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        
        ShoppingCartVm = new ShoppingCartVM()
        {
            cartItems = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value, u => u.ProductId, "Product"),
        };
        foreach (var item in ShoppingCartVm.cartItems)
        {
            item.CartPrice = GetPriceBasedOnQuantity(item.Count, item.Product.UnitPrice,
                item.Product.HalfDozenPrice, item.Product.DozenPrice);
            ShoppingCartVm.CartTotal += (item.CartPrice * item.Count);

        }
        return Page();
        
    }
    
    public IActionResult OnPostMinus(int cartId)
    {
        var cart = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
        if (cart.Count == 1)
        {
            _unitOfWork.ShoppingCart.Delete(cart);
        }


        else
        {
            cart.Count -= 1;


            _unitOfWork.ShoppingCart.Update(cart);
        }
        _unitOfWork.Commit();


        var cnt = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == cart.ApplicationUserId).Count();
        //HttpContext.Session.SetInt32(SD.ShoppingCart, cnt);
        return RedirectToPage();




    }


    public IActionResult OnPostPlus(int cartId)
    {
        var cart = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
        cart.Count += 1;


        _unitOfWork.ShoppingCart.Update(cart);




        _unitOfWork.Commit();




        return RedirectToPage();




    }


    public IActionResult OnPostRemove(int cartId)
    {
        var cart = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
        _unitOfWork.ShoppingCart.Delete(cart);
        _unitOfWork.Commit();
        var cnt = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == cart.ApplicationUserId).Count();
        //HttpContext.Session.SetInt32(SD.ShoppingCart, cnt);
        return RedirectToPage();


    }

    
    private double GetPriceBasedOnQuantity(double quantity, double unitPrice, double priceHalfDozen, double priceDozen)
    {
        if (quantity <= 5)
        {
            return unitPrice;
        }
        else
        {
            if (quantity <= 11)
            {
                return priceHalfDozen;
            }
            return priceDozen;
        }
    }
}

