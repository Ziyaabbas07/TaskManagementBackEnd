using DataLayer.ApplicationDbContext;
using DataLayer.Models;
using ServiceLayer.DTOs.Requests;
using ServiceLayer.DTOs.Responses;
using ServiceLayer.Helpers;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UserService(ApplicationDbContext context) : IUserService
    {
        ApplicationDbContext _context = context;
        public async Task SignUp(SignUpRequest signUpRequest)
        {
            var salt = PasswordHelper.GetSecureSalt();
            var passwordHash = PasswordHelper.HashUsingPbkdf2(signUpRequest.Password,salt);

            var signUp = new Users
            {
                FirstName = signUpRequest.FirstName,
                LastName = signUpRequest.LastName,
                Email = signUpRequest.Email,
                PasswordHash = passwordHash,
                SecurityStamp = Convert.ToBase64String(salt),
                RoleMaster = signUpRequest.Role,
                TeamId = signUpRequest.TeamId,
                PhoneNumber = signUpRequest.PhoneNumber
            };
            _context.Users.Add(signUp);
            await _context.SaveChangesAsync();
        }
        public UserResponse Login(LoginRequest login)
        {
            var user = _context.Users.Where(x=>x.Email == login.Email).FirstOrDefault();
            if (user == null) 
            {
                throw new Exception("User not exist");
            }
            var salt = user.SecurityStamp;
            var passwordHash = PasswordHelper.HashUsingPbkdf2(login.Password, Convert.FromBase64String(salt));
            if (user.PasswordHash != passwordHash)
            {
                throw new Exception("Incorrect Password");
            }
            var response = new UserResponse
            {
                UserId = user.UserId,
                Email = user.Email,
                TeamId=user.TeamId,
                RoleMaster = user.RoleMaster.ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName

            };
            return response;
        }
        public IQueryable GetAllEmployees()
        {
            var data = _context.Users.Where(x=>x.RoleMaster == RoleMaster.Employee).AsQueryable();
            return data;
        }
    }
}
