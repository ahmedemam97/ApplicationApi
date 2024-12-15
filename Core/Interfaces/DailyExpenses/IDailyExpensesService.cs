using Domain.Dto;
using Domain.Entities.DailyExpenses;
using Domain.Entities.DailyRevenue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.DailyExpensess
{
    public interface IDailyExpensesService
    {
        Task<ResponseResult> GetAll();
        Task<ResponseResult> Create(DailyExpensesDto model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Update(DailyExpensesDto model);
        Task<ResponseResult> GetPageInfo();
    }
}
