using ServiceLayer.DTOs.Requests;
using ServiceLayer.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IUserService
    {
        Task SignUp(SignUpRequest signUp);
        UserResponse Login(LoginRequest login);
        IQueryable GetAllEmployees();
    }
}
