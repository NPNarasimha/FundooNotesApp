﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Migrations;

namespace RepositoryLayer.Services
{
    public class UserRepo:IUserRepo
    {
        private readonly FundooDBContext context;
        private readonly IConfiguration configuration;

        public UserRepo(FundooDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public UserEntity Register(RegisterModel model)
        {
            UserEntity user = new UserEntity();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.DOB = model.DOB;
            user.Gender = model.Gender;
            user.Email = model.Email;
            user.Password = EncodePasswordToBase64(model.Password);
            this.context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

       

        //Encooding the password 
        //reference c# scorner
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        //checking email is exist or not
        public bool CheckEmail(string email)
        {
            var result =this.context.Users.FirstOrDefault(x => x.Email == email);
            if (result == null)
            {
                return false;
            }
            return true;
        }
             public string Login(LoginModel model)
                    {
                        var checkUser = context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == EncodePasswordToBase64(model.Password));
           
                        if (checkUser != null)
                        {
                            var token= GenerateToken(checkUser.Email,checkUser.UserId);
                            return token;
                        }
                        return null;
                    }

        public ForgetPasswordModel ForgotPassWord(string Email)
        {
            UserEntity user = context.Users.ToList().Find(user => user.Email == Email);
            ForgetPasswordModel forgotPass=new ForgetPasswordModel(); 
            forgotPass.Email=user.Email;
            forgotPass.UserId=user.UserId;
            forgotPass.Token=GenerateToken(user.Email,user.UserId);
            return forgotPass;
        }

    public bool ResetPassword(string Email,ResetPasswordModel resetPasswordModel)
        {
            UserEntity user = context.Users.ToList().Find(user => user.Email == Email);
            if (CheckEmail(user.Email)){
                user.Password = EncodePasswordToBase64(resetPasswordModel.ConformPassword);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        //get all Users
    public List<UserEntity> GetAllUserS()
        {
            return context.Users.ToList();
        }
        //get By UserId
        public  UserEntity GetUser(int userId)
        {
            var user = context.Users.FirstOrDefault(x => x.UserId == userId);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        //get By Users name startWith 'A'
        public List<UserEntity> GetUsersByName()
        {
            var userByName=context.Users.Where(x => x.FirstName.StartsWith("A")).ToList();
            if (userByName.Any())
            {
                return userByName;
            }
            return null;
        }
        //Count the Number Of Users
        public int TotalUsers()
        {
            int TotalUser= context.Users.Count();
            return TotalUser;
        }

        //Get users ordered by name(ascending & descending)
        public List<UserEntity> GetUserAscOrder()
        {
            var userOrderByName = context.Users.OrderBy(x => x.FirstName).ToList();

            if (userOrderByName.Any())
            {
                return userOrderByName;
            }
            return null;
        }
        public List<UserEntity> GetUserDescOrder()
        {
            var userOrderByName = context.Users.OrderByDescending(x => x.FirstName).ToList();
            if (userOrderByName.Any())
            {
                return userOrderByName;
            }
            return null;
        }

        //Get the average age of users
        public double AverageAge()
        {
            var user = context.Users.ToList();
            double averageAge = user.Select(x => DateTime.Now.Year - x.DOB.Year).Average();
            return averageAge;
        }
        //Get the oldest and youngest user age
        public List<UserEntity> GetOldestUser()
        {
            var user = context.Users.OrderByDescending(x => x.DOB).ToList();
            if(user.Any())
            {
               return user;
            }
            return null;
        }

        private string GenerateToken(string email, int userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("EmailId",email),
                new Claim("UserId",userId.ToString())
            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    
    }
}
