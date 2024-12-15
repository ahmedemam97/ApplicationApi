using Api.Helper;
using Application.Interfaces.Companys;
using Application.Interfaces.Expensess;
using Domain.Entities.Company;
using Domain.Entities.Expenses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.CompanyS
{
    public class CompanyEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapPost("/Company/Update", Update);
            app.MapPost("/Company/Create", Create);
            app.MapGet("/Company/GetAll", GetAll);
            app.MapDelete("/Company/Delete", Delete);
        }
        //[Authorize]
        private async Task<IResult> Update(Company model, ICompanyService service) => Results.Ok(await service.Update(model));
        //[Authorize]
        private async Task<IResult> Create(Company model, ICompanyService service) => Results.Ok(await service.Create(model));
        //[Authorize]
        private async Task<IResult> GetAll(ICompanyService service) => Results.Ok(await service.GetAll());
        //[Authorize]
        private async Task<IResult> Delete([FromQuery] int id, ICompanyService service) => Results.Ok(await service.Delete(id));
    }
}
