using Guohui.BudgetTracker.ApplicationCore.Models.Request;
using Guohui.BudgetTracker.ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guohui.BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenditureController : Controller
    {
        private readonly IExpenditureService _expendituresService;
        public ExpenditureController(IExpenditureService expenditureService)
        {
            _expendituresService = expenditureService;
         
        }

        [HttpPost("{userId:int}/addexpenditure")]
        public async Task<ActionResult> CreateExpenditure([FromBody] ExpenditureRequestModel expenditureRequest,int userId)
        {
            await _expendituresService.AddExpenditure(expenditureRequest, userId);
            return Ok(expenditureRequest);
        }

        [HttpDelete("deleteExpenditure/{id:int}")]
        public async Task<ActionResult> DeleteExpenditure(int id)
        {
            await _expendituresService.DeleteExpenditure(id);
            return Ok();
        }

        [HttpGet("{id:int}/expenditures")]
        public async Task<ActionResult> GetUserExpendituresAsync(int id)
        {
            var userExpenditures = await _expendituresService.ListAllExpendituresByUser(id);
            return Ok(userExpenditures);
        }
        [HttpPut("{userId:int}/updateExpenditure/{expenditureId:int}")]
        public async Task<ActionResult> UpdateExpenditure([FromBody] ExpenditureRequestModel expenditureRequest, int userId, int expenditureId)
        {
            await _expendituresService.UpdateExpenditure(expenditureRequest, userId, expenditureId);
            return Ok();
        }

        [HttpGet("expenditures")]
        public async Task<ActionResult> GetAllExpenditureAsync()
        {
            var userExpenditures = await _expendituresService.ListAllExpenditures();
            return Ok(userExpenditures);
        }


    }
}
