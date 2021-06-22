using Guohui.BudgetTracker.ApplicationCore.Entities;
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
   public class IncomeService :IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeService(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public async Task<IncomeResponseModel> AddIncome(IncomeRequestModel incomeRequest, int userId)
        {
            var income = new Income
            {
                UserId = userId,
                Amount = incomeRequest.Amount,
                Description = incomeRequest.Description,
                IncomeDate = incomeRequest.IncomeDate,
                Remarks = incomeRequest.Remarks,
            };

            var createdIncome = await _incomeRepository.AddAsync(income);
            var response = new IncomeResponseModel
            {
                Id = createdIncome.Id,
                Amount = createdIncome.Amount,
                Description = createdIncome.Description,
                IncomeDate = createdIncome.IncomeDate,
                Remarks = createdIncome.Remarks
            };
            return response;
        }

      
        public async Task<IEnumerable<IncomeResponseModel>> ListAllIncomes()
        {
            var incomes = await _incomeRepository.ListAllAsync();

            var response = new List<IncomeResponseModel>();
            foreach (var income in incomes)
            {
                response.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    Amount = income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks
                });
            }
            return response;
        }

        public async Task<IEnumerable<IncomeResponseModel>> ListAllIncomesByUser(int id)
        {
            var incomes = await _incomeRepository.ListAsync(e => e.UserId == id);
            var response = new List<IncomeResponseModel>();
            foreach (var income in incomes)
            {
                response.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    UserId = income.UserId,
                    Amount = (decimal)income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks,
                });
            }
            return response;
        }

        public async Task<IncomeResponseModel> UpdateIncome(IncomeRequestModel incomeRequest, int userId, int incomeId)
        {
            var income = new Income
            {
                Id = incomeId,
                UserId = userId,
                Amount = incomeRequest.Amount,
                Description = incomeRequest.Description,
                IncomeDate = incomeRequest.IncomeDate,
                Remarks = incomeRequest.Remarks
            };
            var updatedIncome = await _incomeRepository.UpdateAsync(income);
            var response = new IncomeResponseModel
            {
                Id = updatedIncome.Id,
                Amount = updatedIncome.Amount,
                Description = updatedIncome.Description,
                IncomeDate = updatedIncome.IncomeDate,
                Remarks = updatedIncome.Remarks
            };
            return response;
        }
        public async Task DeleteIncome(int id)
        {
            var income = await _incomeRepository.ListAsync(e => e.Id == id);
            await _incomeRepository.DeleteAsync(income.First());
        }
    }
}
