using Guohui.BudgetTracker.ApplicationCore.Models.Request;
using Guohui.BudgetTracker.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guohui.BudgetTracker.ApplicationCore.ServiceInterfaces
{
    public interface IIncomeService
    {
        Task<IncomeResponseModel> AddIncome(IncomeRequestModel incomeRequest, int userId);
        Task<IncomeResponseModel> UpdateIncome(IncomeRequestModel incomeRequest, int userId, int incomeId);
        Task DeleteIncome(int id);      
        Task<IEnumerable<IncomeResponseModel>> ListAllIncomesByUser(int id);
        Task<IEnumerable<IncomeResponseModel>> ListAllIncomes();
    }
}
