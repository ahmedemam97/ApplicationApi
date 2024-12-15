using Domain.Dto;
using Domain.Entities.DailyRevenue;
using Domain.Entities.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Expensess
{
    public interface IExpensesService
    {
        Task<ResponseResult> GetAll();
        Task<ResponseResult> Create(Expenses model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Update(Expenses model);
        Task<ResponseResult> ExpensesSearchInfo();
        Task<ResponseResult> ExpensesSearch(SearchDto searchDto);
    }
}
