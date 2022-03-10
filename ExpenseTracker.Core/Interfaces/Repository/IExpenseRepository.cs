using ExpenseTracker.Core.DTOs;
using ExpenseTracker.Core.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Interfaces
{
    public interface IExpenseRepository
    {
        Task<ExpenseInfo> CreateExpenseAsync(CreateExpenseRequest createExpenseRequest);
        Task<List<ExpenseInfo>> GetAllExpenses();

        //Task<HomeAd> GetHomeAdById(int id);
        //Task<List<HomeAd>> GetHomeAdByUserId(string userId);
        //Task<HomeAd> UpdateHomeAdAsync(HomeAd homeAd);
        //Task<HomeAd> UpdateHomeAdPatchAsync(int homeAdId, JsonPatchDocument homeAdModel);
        Task<bool> DeleteExpenseById(Guid id);
    }
}
