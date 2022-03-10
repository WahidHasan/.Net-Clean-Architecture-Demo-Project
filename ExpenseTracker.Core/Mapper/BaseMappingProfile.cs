using AutoMapper;
using Domain;
using ExpenseTracker.Core.DTOs;
using ExpenseTracker.Core.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mappings
{
    public class BaseMappingProfile : Profile
    {
        public BaseMappingProfile()
        {
            CreateMap<ExpenseInfo, CreateExpenseRequest>().ReverseMap();
        }
    }
}
