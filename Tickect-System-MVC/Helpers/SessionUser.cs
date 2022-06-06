using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Tickect_System_MVC.Models;

namespace Tickect_System_MVC.Helpers
{
    public class SessionUser : ISessionUser
    {
        private readonly IHttpContextAccessor _iHttpContextAccessor;

        public SessionUser(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }

        public void CreateSessionOfUser(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);
            _iHttpContextAccessor.HttpContext.Session.SetString("userLogged", value);
        }

        public UserModel GetSessionUser()
        {
            string value = _iHttpContextAccessor.HttpContext.Session.GetString("userLogged");
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<UserModel>(value);
        }

        public void RemoveSessionOfUser()
        {
            _iHttpContextAccessor.HttpContext.Session.Remove("userLogged");
        }
    }
}
