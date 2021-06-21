﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guohui.BudgetTracker.ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime? JoinedOn { get; set; }
        public ICollection<Income> Incomes { get; set; }
        public ICollection<Expenditure> Expenditures { get; set; }
    }
}
