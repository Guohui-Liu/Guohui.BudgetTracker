using Guohui.BudgetTracker.ApplicationCore.Entities;
using Guohui.BudgetTracker.ApplicationCore.Exceptions;
using Guohui.BudgetTracker.ApplicationCore.Models.Request;
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

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.ListAsync(u => u.Id == id);
            await _userRepository.DeleteAsync(user.First());
        }

        public async Task<UserListResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new
                   NotFoundException("User not found!");
            var response = new UserListResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                FullName = user.FullName,
                JoinedOn = user.JoinedOn,
            };
            return response;
        }

      
        public async Task<List<UserListResponseModel>> ListAllUsers()
        {
            var users = await _userRepository.ListAllAsync();
            var list = new List<UserListResponseModel>();
            foreach (var user in users)
            {
                list.Add(new UserListResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    Password = user.Password,
                    JoinedOn = user.JoinedOn,                  
                });
            }
            return list;
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequest)
        {
            var dbUser = await _userRepository.GetUserByEmail(registerRequest.Email);
            if (dbUser != null && string.Equals(dbUser.Email, registerRequest.Email, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new ConflictException("Email Already exists");
            }
            var user = new User
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                FullName = registerRequest.FullName,
                JoinedOn = registerRequest.JoinedOn
            };
            var createdUser = await _userRepository.AddAsync(user);
            var response = new UserRegisterResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Password = user.Password,
            };
            return response;
        }

        public async Task<UserUpdateRequestModel> UpdateUser(UserUpdateRequestModel userUpdateRequest, int id)
        {
            var dbUser = await _userRepository.GetUserByEmail(userUpdateRequest.Email);

            if (dbUser != null && string.Equals(dbUser.Email, userUpdateRequest.Email, StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Email Already Exits");

            var user = new User
            {
                Id = id,
                JoinedOn = DateTime.Now,
                FullName = userUpdateRequest.FullName,
                Password = userUpdateRequest.Password,
                Email = userUpdateRequest.Email
            };

            var updatedUser = await _userRepository.UpdateAsync(user);
            var response = new UserUpdateRequestModel
            {
                Id = updatedUser.Id,
                Email = updatedUser.Email,
                FullName = updatedUser.FullName
            };
            return response;
        }

        public async Task<UserDetailsResponseModel> GetUserDetailById(int id)
        {
            var userDetail = await _userRepository.GetUserById(id);

            var userResponseModel = new UserDetailsResponseModel
            {
                Id = id,
                FullName = userDetail.FullName,
                Email = userDetail.Email,
                TotalIncomes = userDetail.Incomes.Sum(u => u.Amount),
                TotalExpenditures = userDetail.Expenditures.Sum(u => u.Amount),
            };

            userResponseModel.Incomes = new List<IncomeResponseModel>();
            foreach (var income in userDetail.Incomes)
            {
                userResponseModel.Incomes.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    UserId = income.UserId,
                    Amount = income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks
                });
            }
            userResponseModel.Expenditures = new List<ExpenditureResponseModel>();
            foreach (var expenditure in userDetail.Expenditures)
            {
                userResponseModel.Expenditures.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }

            return userResponseModel;
        }

        //public Task<List<UserListResponseModel>> ListAllUsers()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
