using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Models;
using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace ManagerLayer.Services
{
    public class UserManager:IUserManager
    {
        private readonly IUserRepo userRepo;
        public UserManager(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }
        public UserEntity Register(RegisterModel model)
        {
            return userRepo.Register(model);
        }

        public bool CheckEmail(string email)
        {
            return userRepo.CheckEmail(email);
        }
        public string Login(LoginModel model)
        {
            return userRepo.Login(model);
        }
        public ForgetPasswordModel ForgotPassWord(string Email)
        {
            return userRepo.ForgotPassWord(Email);
        }
        public bool ResetPassword(string Email, ResetPasswordModel resetPasswordModel)
        {
            return userRepo.ResetPassword(Email,resetPasswordModel);
        }

        public List<UserEntity> GetAllUserS()
        {
            return userRepo.GetAllUserS();
        }
        public UserEntity GetUser(int userId)
        {
            return userRepo.GetUser(userId);
        }
        public List<UserEntity> GetUsersByName()
        {
            return userRepo.GetUsersByName();
        }
        public int TotalUsers()
        {
            return userRepo.TotalUsers();
        }
        public List<UserEntity> GetUserAscOrder()
        {
            return userRepo.GetUserAscOrder();
        }
        public List<UserEntity> GetUserDescOrder()
        {
            return userRepo.GetUserDescOrder();
        }
        public double AverageAge()
        {
            return userRepo.AverageAge();
        }
        public List<UserEntity> GetOldestUser()
        {
            return userRepo.GetOldestUser();
        }
    }
}
