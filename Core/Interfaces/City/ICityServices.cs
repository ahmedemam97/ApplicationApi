using Domain.Dto;
using Domain.Entities.City;
using Domain.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Citys
{
    public interface ICityServices
    {
        Task<ResponseResult> GetAll();
        Task<ResponseResult> Create(City model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Update(City model);
    }
}
