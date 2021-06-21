using Guohui.BudgetTracker.ApplicationCore.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guohui.BudgetTracker.ApplicationCore.ServiceInterfaces
{
    public interface IExpenditureService
    {
        Task AddExpenditure(ExpenditureRequestModel expenditureRequest);
        Task DeleteExpenditure(int id);
        //Task<ExpenditureResponseModel> UpdateExpenditure(ExpenditureRequestModel expendituRequest);
        //Task<IEnumerable<ExpenditureResponseModel>> GetAllExpendituresByUser(int id);
        //Task<IEnumerable<ExpenditureResponseModel>> GetAllExpenditures();
    }
}
