using System.Collections.Generic;
using Tickect_System_MVC.Models;

namespace Tickect_System_MVC.Repository
{
    public interface IUserRepository
    {
        public UserModel CreateUserInDataBase(UserModel user);

        public UserModel ComparateIsCpfIsSame(string cpfUser);

        public UserModel LoginValidation (UserLoginModel userLoginModel);

        public List <UserModel> SeachAll();
    }
}
