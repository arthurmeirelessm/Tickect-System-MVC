using Tickect_System_MVC.Models;

namespace Tickect_System_MVC.Repository
{
    public interface IUserRepository
    {
        public UserModel CreateUserinDataBase(UserModel user);
    }
}
