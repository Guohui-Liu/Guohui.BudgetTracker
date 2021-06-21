using Guohui.BudgetTracker.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guohui.BudgetTracker.ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        //Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequest);
        //Task<UserLoginResponseModel> ValidateUser(string email, string password);
        Task<UserRegisterResponseModel> GetUserById(int id);
        //Task<UserDetailResponseModel> GetUserDetailById(int id);

        //Task<UserRequestModel> UpdateUser(UserRequestModel userRequest);
        //Task DeleteUser(int id);

        //Task<List<UserLoginResponseModel>> GetAllUsersasync();
    }
}
