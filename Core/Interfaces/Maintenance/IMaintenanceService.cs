using Domain.Dto;
using Domain.Entities.DailyRevenue;
using Domain.Entities.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Maintenances
{
    public interface IMaintenanceService
    {
        Task<ResponseResult> GetAll();
        Task<ResponseResult> Create(Maintenance model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Update(Maintenance model);
    }
}
