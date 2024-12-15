using Domain.Dto.RevenueDto;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Bookings;

namespace Application.Interfaces.Bookingss
{
    public interface IBookingsService
    {
        Task<ResponseResult> GetPageInfo();
        Task<ResponseResult> GetAll();
        Task<ResponseResult> Create(Bookings model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Update(Bookings model);
    }
}
