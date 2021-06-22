using Guohui.BudgetTracker.ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guohui.BudgetTracker.API.Controllers
{
    public class ExpenditureController : Controller
    {
        private readonly IExpenditureService _expendituresService;
        public ExpenditureController(IExpenditureService expenditureService)
        {
            _expendituresService = expenditureService;
         
        }
    }
}
