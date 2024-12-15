

using Domain.Dto;
using Domain.Entities.Company;
using Domain.Entities.DailyExpenses;

namespace Application.Interfaces.Companys
{
    public interface ICompanyService
    {
        Task<ResponseResult> GetAll();
        Task<ResponseResult> Create(Company model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Update(Company model);
    }
}
