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

        [HttpPost("")]
        public async Task<ActionResult> CreateExpenditure([FromBody] ExpenditureRequestModel expenditureRequest)
        {
            var expenditureResponse = await _expendituresService.AddExpenditure(expenditureRequest);
            return Ok(expenditureResponse);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteExpenditure(int id)
        {
            await _expendituresService.DeleteExpenditure(id);
            return Ok();
        }

        [HttpGet("User/{userId:int}")]
        public async Task<ActionResult> GetUserExpendituresAsync(int userId)
        {
            var userExpenditures = await _expendituresService.ListAllExpendituresByUser(userId);
            return Ok(userExpenditures);
        }
        [HttpPut("{Id:int}")]
        public async Task<ActionResult> UpdateExpenditure([FromBody] ExpenditureRequestModel expenditureRequest, int Id)
        {
            var response = await _expendituresService.UpdateExpenditure(expenditureRequest, Id);
            return Ok(response);
        }

        [HttpGet("expenditures")]
        public async Task<ActionResult> GetAllExpenditureAsync()
        {
            var userExpenditures = await _expendituresService.ListAllExpenditures();
            return Ok(userExpenditures);
        }


    }
}
