using AutoMapper;
using ExpenseTracker.Core.DTOs;
using ExpenseTracker.Core.Expense;
using ExpenseTracker.Core.Interfaces;
using ExpenseTracker.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly IBaseRepository<ExpenseInfo> _repository;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ExpenseRepository(IBaseRepository<ExpenseInfo> repository, ApplicationDbContext context, IMapper mapper)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;
        }
        public async Task<ExpenseInfo> CreateExpenseAsync(CreateExpenseRequest createExpenseRequest)
        {
            var mappedData = _mapper.Map<ExpenseInfo>(createExpenseRequest);
            return await _repository.AddAsync(mappedData);
        }

        public async Task<bool> DeleteExpenseById(Guid expenseId)
        {
            var expense = await _repository.GetByIdAsync(expenseId);
            if(expense != null)
            {
                return await _repository.DeleteAsync(expense);
            }
            return default;
        }

        public async Task<List<ExpenseInfo>> GetAllExpenses()
        {
            List<ExpenseInfo> allExpenses = await _repository.GetAllAsync();
            return allExpenses;
        }
    }
}
