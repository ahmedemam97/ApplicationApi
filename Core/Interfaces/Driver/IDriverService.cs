using Domain.Dto;
using Domain.Entities.DailyExpenses;
using Domain.Entities.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Drivers
{
    public interface IDriverService
    {
        Task<ResponseResult> GetAll();
        Task<ResponseResult> Create(Driver model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Update(Driver model);
    }
}
