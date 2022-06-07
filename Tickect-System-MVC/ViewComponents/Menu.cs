using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Tickect_System_MVC.Models;

namespace Tickect_System_MVC.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userSession = HttpContext.Session.GetString("userLogged");
            if (string.IsNullOrEmpty(userSession))
            {
                return null;
            }

            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);
            return View(user);
        }

    }
}
