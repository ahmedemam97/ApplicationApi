using Domain.Dto;
using Domain.Dto.RevenueDto;
using Domain.Entities.DailyRevenue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.DailyRevenues
{
    public interface IDailyRevenueServices
    {
        Task<ResponseResult> GetPageInfo();
        Task<ResponseResult> GetAll();
        Task<ResponseResult> RevenueSearchInfo();
        Task<ResponseResult> RevenueSearch(SearchDto searchDto);
        Task<ResponseResult> Create(DailyRevenueDto model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Update(DailyRevenueDto model);
    }
}
