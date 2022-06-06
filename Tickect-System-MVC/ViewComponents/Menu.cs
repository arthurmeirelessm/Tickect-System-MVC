using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Tickect_System_MVC.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}
