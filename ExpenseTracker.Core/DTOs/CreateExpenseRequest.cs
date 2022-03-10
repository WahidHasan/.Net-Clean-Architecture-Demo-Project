using ExpenseTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.DTOs
{
    public class CreateExpenseRequest
    {
        [Required]
        public string ExpenseName { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public ExpenseType Type { get; set; }
        public string Details { get; set; }
        public string Note { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }

    public class ExpenseResponse
    {
        public string ExpenseName { get; set; }
        public int Amount { get; set; }
        public ExpenseType Type { get; set; }
        public string Details { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
    }
}
