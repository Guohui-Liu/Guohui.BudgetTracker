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
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {          
            _incomeService = incomeService;
        }

        [HttpPost("{userId}addIncome")]
        public async Task<ActionResult> CreateIncome([FromBody] IncomeRequestModel incomeRequest, int userId)
        {
            await _incomeService.AddIncome(incomeRequest, userId);
            return Ok();
        }

        [HttpDelete("deleteIncome/{id:int}")]
        public async Task<ActionResult> DeleteIncome(int id)
        {
            await _incomeService.DeleteIncome(id);
            return Ok();
        }

        [HttpGet("{id:int}/incomes")]
        public async Task<ActionResult> ListUserIncomesAsync(int id)
        {
            var userIncomes = await _incomeService.ListAllIncomesByUser(id);
            return Ok(userIncomes);
        }
        [HttpPut("{userId:int}/updateIncome/{incomeId:int}")]
        public async Task<ActionResult> UpdateIncome([FromBody] IncomeRequestModel incomeRequest, int userId, int incomeId)
        {
            await _incomeService.UpdateIncome(incomeRequest, userId, incomeId);
            return Ok();
        }

        [HttpGet("incomes")]
        public async Task<ActionResult> ListAllIncomesAsync()
        {
            var userIncomes = await _incomeService.ListAllIncomes();
            return Ok(userIncomes);
        }

    }
}
