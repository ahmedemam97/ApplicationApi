using Domain.Dto;
using Domain.Entities.Company;
using Domain.Entities.DriverExpenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.DriverExpensesS
{
    public interface IDriverExpensesService
    {
        
        Task<ResponseResult> GetPageInfo();
        Task<ResponseResult> GetAll();
        Task<ResponseResult> Create(DriverExpenses model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Update(DriverExpenses model);
        Task<ResponseResult> DriverExpensesSearch(DriverSearchDto model);
        
    }
}
