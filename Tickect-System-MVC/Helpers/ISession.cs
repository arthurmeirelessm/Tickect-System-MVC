using Tickect_System_MVC.Models;

namespace Tickect_System_MVC.Helpers
{
    public interface ISession
    {
        public void CreateSessionOfUser(UserModel user);
        public void RemoveSessionOfUser();
        UserModel GetSessionUser();
    }

}