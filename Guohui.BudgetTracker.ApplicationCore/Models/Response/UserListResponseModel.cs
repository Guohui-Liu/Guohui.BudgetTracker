﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guohui.BudgetTracker.ApplicationCore.Models.Response
{
    public class UserListResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? FullName { get; set; }
        public string Password { get; set; }
        public DateTime? JoinedOn { get; set; }
    }
}
