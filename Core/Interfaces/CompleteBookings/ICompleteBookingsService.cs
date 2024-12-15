using Domain.Dto;
using Domain.Entities.CompanyAPP;
using Domain.Entities.CompleteBookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CompleteBookingss
{
    public interface ICompleteBookingsService
    {

        Task<ResponseResult> GetPageInfo();
        Task<ResponseResult> GetAll();
        Task<ResponseResult> Create(CompleteBookings model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Update(CompleteBookings model);
    }
}
