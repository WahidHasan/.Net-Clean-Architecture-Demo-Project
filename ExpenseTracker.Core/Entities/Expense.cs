using Domain.Common;
using ExpenseTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Expense
{
    public class ExpenseInfo : AuditableEntity
    {
        public string ExpenseName { get; set; }
        public int Amount { get; set; }
        public ExpenseType Type { get; set; }
        public string Details { get; set; }
        public string Note { get; set; }

        public DateTime Date { get; set; }
    }
}
