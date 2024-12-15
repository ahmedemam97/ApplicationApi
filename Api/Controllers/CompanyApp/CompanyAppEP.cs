using Api.Helper;
using Application.Interfaces.CompanyAPPS;
using Application.Interfaces.Companys;
using Application.Interfaces.Expensess;
using Domain.Entities.Company;
using Domain.Entities.CompanyAPP;
using Domain.Entities.Expenses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.CompanyApp
{
    public class CompanyAppEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapPost("/CompanyApp/Update", Update);
            app.MapPost("/CompanyApp/Create", Create);
            app.MapGet("/CompanyApp/GetAll", GetAll);
            app.MapDelete("/CompanyApp/Delete", Delete);
        }
        //[Authorize]
        private async Task<IResult> Update(CompanyAPP model, ICompanyAppService service) => Results.Ok(await service.Update(model));
        //[Authorize]
        private async Task<IResult> Create(CompanyAPP model, ICompanyAppService service) => Results.Ok(await service.Create(model));
        //[Authorize]
        private async Task<IResult> GetAll(ICompanyAppService service) => Results.Ok(await service.GetAll());
        //[Authorize]
        private async Task<IResult> Delete([FromQuery] int id, ICompanyAppService service) => Results.Ok(await service.Delete(id));
    }
}
