using ExpenseTracker.Core.DTOs;
using ExpenseTracker.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _expense;

        public ExpenseController(IExpenseRepository expense)
        {
            _expense = expense;
        }
        // GET: api/<ExpenseController>
        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            var response = await _expense.GetAllExpenses();
            return Ok(response);
        }

        // POST api/<ExpenseController>
        [HttpPost]
        public async Task<IActionResult> CreateExpense(CreateExpenseRequest createExpenseRequest)
        {
            var expenseResponse = await _expense.CreateExpenseAsync(createExpenseRequest);
            return Ok(expenseResponse);
        }

        // DELETE api/<ExpenseController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteResponse(Guid id)
        {
            return await _expense.DeleteExpenseById(id);
        }
    }
}
