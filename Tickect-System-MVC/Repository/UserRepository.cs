using System;
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

        public UserModel CreateUserinDataBase(UserModel user)
        {
            user.CreatedAt = DateTime.Now;
            _dataContext.Add(user); 
            _dataContext.SaveChanges();

            return user;
        }
    }
}
