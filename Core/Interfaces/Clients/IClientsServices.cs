using Domain.Dto;
using Domain.Entities.Clients;
using Domain.Entities.DailyExpenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Clientss
{
    public interface IClientsServices
    {
        Task<ResponseResult> GetAll();
        Task<ResponseResult> Create(Clients model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Update(Clients model);
    }
}
