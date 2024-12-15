using Application.Interfaces.Expensess;
using Domain.Dto;
using Domain.Entities.Expened;
using Domain.Entities.Expenses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Expeneds
{
    public interface IExpenedService
    {
        Task<ResponseResult> Create(Expened model);
        Task<ResponseResult> Update(Expened model);
        Task<ResponseResult> GetAll();
    }
}
