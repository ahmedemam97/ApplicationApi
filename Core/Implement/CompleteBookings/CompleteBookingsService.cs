using Application.Interfaces;
using Application.Interfaces.CompleteBookingss;
using AutoMapper;
using Domain.Dto;
using Domain.Entities.Bookings;
using Domain.Entities.Company;
using Domain.Entities.CompanyAPP;
using Domain.Entities.CompleteBookings;
using Domain.Entities.DailyExpenses;
using Domain.Entities.DailyRevenue;
using Domain.Entities.Driver;
using Domain.Entities.DriverExpenses;
using Domain.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implement.CompleteBookingss
{
    public class CompleteBookingsService: ICompleteBookingsService
    {
        private readonly IUnitOfWork UnitOFWork;
        private IMapper _mapper;
        private JwtHelper _jwtHelper;
        private string Id;
        private string Name;
        public CompleteBookingsService(
                  IUnitOfWork unitOfWork,
                         JwtHelper jwtHelper,
                   IMapper mapper)
        {
            UnitOFWork = unitOfWork;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            Id = _jwtHelper.ReadTokenClaim(TokenClaimType.Id);
            Name = _jwtHelper.ReadTokenClaim(TokenClaimType.UserName);
        }
        public async Task<ResponseResult> GetPageInfo()
        {
            var CompanyList = await UnitOFWork.Repository<Company>().ToListAsync();

            var BookingsList = await UnitOFWork.Repository<Bookings>()
                .Where(e=>e.Completed == false)
                .ToListAsync();

            return new ResponseResult { IsSuccess = true, Message = "none", Obj = new {
             CompanyList,
             BookingsList
            } };
        }
        public async Task<ResponseResult> Create(CompleteBookings model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Null" };

            if (model.BookingsId <= 0)
                return new ResponseResult { IsSuccess = false, Message = "اختر الرحلة" };

            if (model.DoneById == 1)
            {
                if (model.Amount <= 0)
                    return new ResponseResult { IsSuccess = false, Message = "ادخل المبلغ" };
            }
            if (model.DoneById == 2)
            {
                if (model.CompanyId <= 0)
                    return new ResponseResult { IsSuccess = false, Message = "اختر الشركة" };

                var Company = await UnitOFWork.Repository<Company>()
                             .Where(e => e.Id == model.CompanyId).FirstOrDefaultAsync();
                if (Company == null)
                    return new ResponseResult { IsSuccess = false, Message = "  الشركة الي  غير موجود" };
                model.CompanyName = Company.Name;



                if (model.Amount <= 0)
                    return new ResponseResult { IsSuccess = false, Message = "ادخل المبلغ" };
            }
            if (model.DoneById == 3)
            {
                if (model.Reason == null || model.Reason == "")
                    return new ResponseResult { IsSuccess = false, Message = "ادخل سبب الالغاء" };
            }

            var BookingsExist = await UnitOFWork.Repository<Bookings>().
               Where(e => e.Id == model.BookingsId).FirstOrDefaultAsync();
            if (BookingsExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            BookingsExist.Completed = true;
            model.CreatedById = Id;
            model.CreatedByName = Name;

            model.ClientId = BookingsExist.ClientId;
            model.ClientName = BookingsExist.ClientName;
            model.TravelType = BookingsExist.TravelType;
            model.Date = BookingsExist.Date;

         
                var DailyRevenue = new DailyRevenue();
                DailyRevenue.RevenueDetails = new List<RevenueDetails>();

                var RevenueDetails = new RevenueDetails()
                {
                    Date = BookingsExist.Date,
                    Amount = model.Amount,
                    CreatedById = Id,
                    CreatedByName = Name,
                    CreatedDate = DateTime.Now,
                    Flag = RevenueFlag.Travel,                  
                };
                DailyRevenue.Date = BookingsExist.Date;
                DailyRevenue.Name = "ايراد رحلة";
                DailyRevenue.RevenueDetails.Add(RevenueDetails);
                DailyRevenue.Flag = RevenueFlag.Travel;
                await UnitOFWork.Repository<DailyRevenue>().AddAsync(DailyRevenue);
                await UnitOFWork.CompleteAsync();
                model.RevenueId = DailyRevenue.Id;
                DailyRevenue.NetTotal = model.Amount;
                DailyRevenue.CreatedById = Id;
                DailyRevenue.CreatedByName = Name;
                await UnitOFWork.Repository<CompleteBookings>().AddAsync(model);
                await UnitOFWork.CompleteAsync();
                return new ResponseResult
                {
                    IsSuccess = true,
                    Message = "Add Success",
                    Obj = model
                };
           

        }
        public async Task<ResponseResult> Delete(int id)
        {
            if (id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };

            var modelExist = await UnitOFWork.Repository<CompleteBookings>().
                         Where(e => e.Id == id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };


            var BookingsExist = await UnitOFWork.Repository<Bookings>().
             Where(e => e.Id == modelExist.BookingsId).FirstOrDefaultAsync();
            if (BookingsExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            BookingsExist.Completed = false;

            if (modelExist.RevenueId > 0)
            {
                var DailyRevenue = await UnitOFWork.Repository<DailyRevenue>()
            .Where(e => e.Id == modelExist.RevenueId)
            .Include(e => e.RevenueDetails).FirstOrDefaultAsync();

              var x = UnitOFWork.Repository<RevenueDetails>().DeleteRange(DailyRevenue.RevenueDetails);
              var i1 = await UnitOFWork.Repository<DailyRevenue>().DeleteAsync(DailyRevenue.Id);

            }
           


            var i2 = await UnitOFWork.Repository<CompleteBookings>().DeleteAsync(modelExist.Id);

            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Delete Success",
                Obj = modelExist.Id
            };
        }
        public async Task<ResponseResult> GetAll()
        {
            var CompleteBookingsList = await UnitOFWork.Repository<CompleteBookings>().ToListAsync();
            var CompanyList = await UnitOFWork.Repository<Company>().ToListAsync();

            if (CompleteBookingsList == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };
            return new ResponseResult { IsSuccess = true, Message = "none", Obj = 
                new {


                    CompleteBookingsList,
                    CompanyList


                } };
        }
        public async Task<ResponseResult> Update(CompleteBookings model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.DoneById == 1)
            {
                if (model.Amount <= 0)
                    return new ResponseResult { IsSuccess = false, Message = "ادخل المبلغ" };
            }
            if (model.DoneById == 2)
            {
                if (model.CompanyId <= 0)
                    return new ResponseResult { IsSuccess = false, Message = "اختر الشركة" };

                var Company = await UnitOFWork.Repository<Company>()
                             .Where(e => e.Id == model.CompanyId).FirstOrDefaultAsync();
                if (Company == null)
                    return new ResponseResult { IsSuccess = false, Message = "  الشركة الي  غير موجود" };
                model.CompanyName = Company.Name;



                if (model.Amount <= 0)
                    return new ResponseResult { IsSuccess = false, Message = "ادخل المبلغ" };
            }
            if (model.DoneById == 3)
            {
                if (model.Reason == null || model.Reason == "")
                    return new ResponseResult { IsSuccess = false, Message = "ادخل سبب الالغاء" };
            }

            var modelExist = await UnitOFWork.Repository<CompleteBookings>().
               Where(e => e.Id == model.Id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            var BookingsExist = await UnitOFWork.Repository<Bookings>().
                 Where(e => e.Id == modelExist.BookingsId).FirstOrDefaultAsync();
            if (BookingsExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            var DailyRevenue = await UnitOFWork.Repository<DailyRevenue>()
                  .Include(e => e.RevenueDetails)
                        .Where(e => e.Id == modelExist.RevenueId).FirstOrDefaultAsync();

                UnitOFWork.Repository<RevenueDetails>().DeleteRange(DailyRevenue.RevenueDetails);
                DailyRevenue.NetTotal = 0;
                var RevenueDetails = new RevenueDetails()
                {
                    Date = BookingsExist.Date,
                    Amount = model.Amount,
                    CreatedById = Id,
                    CreatedByName = Name,
                    CreatedDate = DateTime.Now,
                    Flag = RevenueFlag.Travel,
                };
                DailyRevenue.Date = BookingsExist.Date;
                DailyRevenue.Name = "ايراد رحلة";
                DailyRevenue.RevenueDetails.Add(RevenueDetails);
                DailyRevenue.NetTotal = model.Amount;
                DailyRevenue.ModifyById = Id;
                DailyRevenue.ModifyByName = Name;
                DailyRevenue.ModifyCount = DailyRevenue.ModifyCount + 1;
                DailyRevenue.Flag = RevenueFlag.Travel;

            //
            model.ClientId = BookingsExist.ClientId;
            model.ClientName = BookingsExist.ClientName;
            model.TravelType = BookingsExist.TravelType;
            model.Date = BookingsExist.Date;
            //
            //
            model.LastModifiedDate = DateTime.Now;
            model.ModifyById = Id;
            model.ModifyByName = Name;
            model.ModifyCount = modelExist.ModifyCount + 1;
            //
                modelExist.RevenueId = DailyRevenue.Id;
                model.RevenueId = DailyRevenue.Id;
                model.BookingsId = modelExist.BookingsId;
                await UnitOFWork.CompleteAsync();
                var MapModel1 = _mapper.Map(model, modelExist);
                var i1 = await UnitOFWork.Repository<CompleteBookings>().UpdateAsync(MapModel1);
                await UnitOFWork.CompleteAsync();

                return new ResponseResult
                {
                    IsSuccess = true,
                    Message = "Update Success",
                    Obj = model
                };
            

        }
    }
}
