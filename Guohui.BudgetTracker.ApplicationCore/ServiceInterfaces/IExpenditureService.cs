using Guohui.BudgetTracker.ApplicationCore.Models.Request;
using Guohui.BudgetTracker.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guohui.BudgetTracker.ApplicationCore.ServiceInterfaces
{
    public interface IExpenditureService
    {
        Task<ExpenditureResponseModel> AddExpenditure(ExpenditureRequestModel expenditureRequest);
        Task DeleteExpenditure(int id);
        Task<ExpenditureResponseModel> UpdateExpenditure(ExpenditureRequestModel expendituRequest, int expenditureId);
        Task<IEnumerable<ExpenditureResponseModel>> ListAllExpendituresByUser(int id);
        Task<IEnumerable<ExpenditureResponseModel>> ListAllExpenditures();

    }
}
