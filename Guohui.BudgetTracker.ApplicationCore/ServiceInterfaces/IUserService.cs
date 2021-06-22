using Guohui.BudgetTracker.ApplicationCore.Models.Request;
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
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequest);
        //Task<UserLoginResponseModel> ValidateUser(string email, string password);
        Task<UserListResponseModel> GetUserById(int id);
       

        Task<UserUpdateRequestModel> UpdateUser(UserUpdateRequestModel userRequest);
        Task DeleteUser(int id);

        Task<List<UserListResponseModel>> ListAllUsersasync();
        Task<UserDetailsResponseModel> GetUserDetailById(int id);
    }
}
