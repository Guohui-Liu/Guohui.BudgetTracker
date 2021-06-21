using Guohui.BudgetTracker.ApplicationCore.Exceptions;
using Guohui.BudgetTracker.ApplicationCore.Models.Response;
using Guohui.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using Guohui.BudgetTracker.ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guohui.BudgetTracker.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserRegisterResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new
                   NotFoundException("User not found!");

            var response = new UserRegisterResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                FullName = user.FullName,

            };
            return response;
        }
    }
}
