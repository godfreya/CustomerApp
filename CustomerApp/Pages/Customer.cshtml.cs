using CustomerAPI.Models;
using CustomerApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerApp.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public CustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task OnGet(int id)
        {
            ViewData["Customer"] = await _customerService.GetCustomerById(id);
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _customerService.Delete(id);
            
            return RedirectToPage("Index");
        }
    }
}
