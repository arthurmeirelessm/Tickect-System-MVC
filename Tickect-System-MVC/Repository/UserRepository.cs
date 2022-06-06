using System;
using System.Collections.Generic;
using System.Linq;
using Tickect_System_MVC.Data;
using Tickect_System_MVC.Models;

namespace Tickect_System_MVC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public UserModel CreateUserInDataBase(UserModel user)
        {

            UserModel comparateCpf = ComparateIsCpfIsSame(user);
            if (comparateCpf is not null)
            {
                throw new Exception("User already exists");
            }

            user.CreatedAt = DateTime.Now;
            _dataContext.Add(user);
            _dataContext.SaveChanges();

            return user;
        }
        public UserModel ComparateIsCpfIsSame(UserModel user)
        {
          return _dataContext.Users.FirstOrDefault(x => x.CPFNumber == user.CPFNumber);
        }

        public UserModel LoginValidation(UserLoginModel userLoginModel)
        {
            var comparateLogin = _dataContext.Users.FirstOrDefault(x => x.Email == userLoginModel.Email && x.Password == userLoginModel.Password);

            if (comparateLogin is not null)
            {
                return comparateLogin;
            }
            throw new Exception("You are not registered here, try to register");
        }

        public List<UserModel> SeachAll()
        {
            return _dataContext.Users.ToList(); 
        }

        public UserModel ConvertPasswordToId(UserLoginModel userLoginModel)
        { 
            var convertion = _dataContext.Users.FirstOrDefault(x => x.Password == userLoginModel.Password);
            if (convertion is not null)
            {
                return 
            }
        }
    }
}
