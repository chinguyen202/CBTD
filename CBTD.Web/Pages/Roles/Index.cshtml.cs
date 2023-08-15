using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTD.Web.Pages.Roles;

public class Index : PageModel
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public Index(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public IEnumerable<IdentityRole> RolesObj { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }

    public async Task OnGetAsync(bool success = false, string message = null)
    {
        Success = success;
        Message = message;
        RolesObj = _roleManager.Roles;

    }

}