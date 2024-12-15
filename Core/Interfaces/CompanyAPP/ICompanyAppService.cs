using Domain.Dto;
using Domain.Entities.Company;
using Domain.Entities.CompanyAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CompanyAPPS
{
    public interface ICompanyAppService
    {
        Task<ResponseResult> GetAll();
        Task<ResponseResult> Create(CompanyAPP model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Update(CompanyAPP model);
    }
}
