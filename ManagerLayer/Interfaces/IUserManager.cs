using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Models;
using RepositoryLayer.Entity;

namespace ManagerLayer.Interfaces
{
    public interface IUserManager
    {
        public UserEntity Register(RegisterModel model);
        public bool CheckEmail(string email);

        public string Login(LoginModel model);

        public ForgetPasswordModel ForgotPassWord(string Email);
        public bool ResetPassword(string Email, ResetPasswordModel resetPasswordModel);
        public List<UserEntity> GetAllUserS();
        public UserEntity GetUser(int userId);
        public List<UserEntity> GetUsersByName();
        public int TotalUsers();
        public List<UserEntity> GetUserAscOrder();
        public List<UserEntity> GetUserDescOrder();
        public double AverageAge();
        public List<UserEntity> GetOldestUser();
    }
}
