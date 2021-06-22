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
    public class ExpenditureService : IExpenditureService
    {
        private readonly IAsyncRepository<Expenditure> _expenditureRepository;

        public ExpenditureService(IAsyncRepository<Expenditure> expenditureRepository)
        {
            _expenditureRepository = expenditureRepository;
        }

        public async Task<ExpenditureResponseModel> AddExpenditure(ExpenditureRequestModel expenditureRequest, int userId)
        {
            var expenditure = new Expenditure
            {
                UserId = userId,
                Amount = expenditureRequest.Amount,
                Description = expenditureRequest.Description,
                ExpDate = expenditureRequest.ExpDate,
                Remarks = expenditureRequest.Remarks
            };
            var createdExpenditure = await _expenditureRepository.AddAsync(expenditure);
            var response = new ExpenditureResponseModel
            {
                Id = createdExpenditure.Id,
                Amount = createdExpenditure.Amount,
                Description = createdExpenditure.Description,
                ExpDate = createdExpenditure.ExpDate,
                Remarks = createdExpenditure.Remarks
            };
            return response;
        }

        public async Task DeleteExpenditure(int id)
        {
            var expenditure = await _expenditureRepository.ListAsync(e => e.Id == id);
            await _expenditureRepository.DeleteAsync(expenditure.First());
        }


        public async Task<ExpenditureResponseModel> UpdateExpenditure(ExpenditureRequestModel expenditureRequest, int userId, int expenditureId)
        {
            var expenditure = new Expenditure
            {
                Id = expenditureId,
                UserId = userId,
                Amount = expenditureRequest.Amount,
                Description = expenditureRequest.Description,
                ExpDate = expenditureRequest.ExpDate,
                Remarks = expenditureRequest.Remarks,
            };
            var updatedExpenditure = await _expenditureRepository.UpdateAsync(expenditure);
            var response = new ExpenditureResponseModel
            {
                UserId = updatedExpenditure.UserId,
                Amount = updatedExpenditure.Amount,
                Description = updatedExpenditure.Description,
                ExpDate = updatedExpenditure.ExpDate,
                Remarks = updatedExpenditure.Remarks,
            };
            return response;
        }


        public async Task<IEnumerable<ExpenditureResponseModel>> ListAllExpendituresByUser(int id)
        {
            var expenditures = await _expenditureRepository.ListAsync(e => e.UserId == id);
            var response = new List<ExpenditureResponseModel>();
            foreach (var expenditure in expenditures)
            {
                response.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks,
                });
            }
            return response;
        }

        public async Task<IEnumerable<ExpenditureResponseModel>> ListAllExpenditures()
        {
            var expenditures = await _expenditureRepository.ListAllAsync();
            var response = new List<ExpenditureResponseModel>();
            foreach (var expenditure in expenditures)
            {
                response.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks,
                });
            }
            return response;
        }

    }
}
