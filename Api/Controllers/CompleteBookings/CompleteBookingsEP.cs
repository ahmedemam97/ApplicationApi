using Api.Helper;
using Application.Interfaces.CompleteBookingss;
using Application.Interfaces.DailyRevenues;
using Domain.Dto.RevenueDto;
using Domain.Entities.CompleteBookings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.CompleteBookingsS
{
    public class CompleteBookingsEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapGet("/CompleteBooking/GetPageInfo", GetPageInfo);
            app.MapPost("/CompleteBooking/Update", Update);
            app.MapPost("/CompleteBooking/Create", Create);
            app.MapGet("/CompleteBooking/GetAll", GetAll);
            app.MapDelete("/CompleteBooking/Delete", Delete);
        }
        //[Authorize]
        private async Task<IResult> GetPageInfo(ICompleteBookingsService service) => Results.Ok(await service.GetPageInfo());
        //[Authorize]
        private async Task<IResult> Update(CompleteBookings model, ICompleteBookingsService service) => Results.Ok(await service.Update(model));
        //[Authorize]
        private async Task<IResult> Create(CompleteBookings model, ICompleteBookingsService service) => Results.Ok(await service.Create(model));
        //[Authorize]
        private async Task<IResult> GetAll(ICompleteBookingsService service) => Results.Ok(await service.GetAll());
        //[Authorize]
        private async Task<IResult> Delete([FromQuery] int id, ICompleteBookingsService service) => Results.Ok(await service.Delete(id));
    }







}
