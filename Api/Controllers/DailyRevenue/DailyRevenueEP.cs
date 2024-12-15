
using Api.Helper;
using Application.Interfaces.DailyRevenues;
using Domain.Dto;
using Domain.Dto.RevenueDto;
using Domain.Entities.DailyRevenue;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.DailyRevenues
{
    public class DailyRevenueEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapGet("/DailyRevenue/GetPageInfo", GetPageInfo);
            app.MapPost("/DailyRevenue/Update", Update);
            app.MapPost("/DailyRevenue/Create", Create);
            app.MapGet("/DailyRevenue/GetAll", GetAll);
            app.MapDelete("/DailyRevenue/Delete", Delete);
            app.MapGet("/DailyRevenue/RevenueSearchInfo", RevenueSearchInfo);
            app.MapPost("/DailyRevenue/RevenueSearch", RevenueSearch);

        }
        //[Authorize]
        private async Task<IResult> RevenueSearchInfo(IDailyRevenueServices service) => Results.Ok(await service.RevenueSearchInfo());
        //[Authorize]
        private async Task<IResult> RevenueSearch(SearchDto model, IDailyRevenueServices service) => Results.Ok(await service.RevenueSearch(model));
        //[Authorize]
        private async Task<IResult> GetPageInfo(IDailyRevenueServices service) => Results.Ok(await service.GetPageInfo());
        //[Authorize]
        private async Task<IResult> Update(DailyRevenueDto model, IDailyRevenueServices service) => Results.Ok(await service.Update(model));
        //[Authorize]
        private async Task<IResult> Create(DailyRevenueDto model, IDailyRevenueServices service) => Results.Ok(await service.Create(model));
        //[Authorize]
        private async Task<IResult> GetAll(IDailyRevenueServices service) => Results.Ok(await service.GetAll());
        //[Authorize]
        private async Task<IResult> Delete([FromQuery] int id, IDailyRevenueServices service) => Results.Ok(await service.Delete(id));
    }
}
