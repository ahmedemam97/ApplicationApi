using Domain.Dto;
using Domain.Entities.City;
using Domain.Entities.PrivateTours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.PrivateTourss
{
    public interface IPrivateToursService
    {
        Task<ResponseResult> GetAll();
        Task<ResponseResult> Create(PrivateTours model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Update(PrivateTours model);
    }
}
