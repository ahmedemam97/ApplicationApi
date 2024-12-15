using Application.Interfaces;
using Application.Interfaces.Bookingss;
using AutoMapper;
using Domain.Dto;
using Domain.Entities.Bookings;
using Domain.Entities.City;
using Domain.Entities.Clients;
using Domain.Entities.Company;
using Domain.Entities.CompleteBookings;
using Domain.Entities.DailyRevenue;
using Domain.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implement.BookingsS
{
    public class BookingsService: IBookingsService
    {
        private readonly IUnitOfWork UnitOFWork;
        private IMapper _mapper;
        private JwtHelper _jwtHelper;
        private string Id;
        private string Name;
        public BookingsService(
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
            var ClientList = await UnitOFWork.Repository<Clients>().ToListAsync();
            var CityList = await UnitOFWork.Repository<City>().ToListAsync();
            var CompanyList = await UnitOFWork.Repository<Company>().ToListAsync();
            var BookingsList = await UnitOFWork.Repository<Bookings>().ToListAsync();

            return new ResponseResult { IsSuccess = true, Message = "none", Obj = new {
                ClientList,
                CityList,
                CompanyList,
                BookingsList
            } };
        }
        public async Task<ResponseResult> Create(Bookings model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Null" };

            if (model.ClientId <=0 )
                return new ResponseResult { IsSuccess = false, Message = "ادخل العميل  " };

            if (model.ClientPhone == "" || model.ClientPhone == null)
                return new ResponseResult { IsSuccess = false, Message = "ادخل رقم العميل  " };

            if (model.Date == null)
                return new ResponseResult { IsSuccess = false, Message = "ادخل  تاريخ الرحله  " };

            if (model.AddressFrom == null || model.AddressFrom == "")
                return new ResponseResult { IsSuccess = false, Message = "ادخل عنوان الرحله من " };

            if (model.AddressTo == null || model.AddressTo == "")
                return new ResponseResult { IsSuccess = false, Message = "ادخل عنوان الرحله الي " };

            if (model.CityFromId <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل المحافظة من " };

            if (model.CityToId <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل المحافظة الي " };

            if (model.TravelType <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل  نوع الرحله " };

            var client = await UnitOFWork.Repository<Clients>()
                .Where(e => e.Id == model.ClientId).FirstOrDefaultAsync();
            if (client == null)
                return new ResponseResult { IsSuccess = false, Message = "   العميل غير موجود" };
            model.ClientName = client.Name;

            var cityFrom = await UnitOFWork.Repository<City>()
                .Where(e => e.Id == model.CityFromId).FirstOrDefaultAsync();
            if (cityFrom == null)
                return new ResponseResult { IsSuccess = false, Message = "  مدينة من  غير موجود" };
            model.CityFromName = cityFrom.Name;


            var cityTo = await UnitOFWork.Repository<City>()
              .Where(e => e.Id == model.CityToId).FirstOrDefaultAsync();
            if (cityTo == null)
                return new ResponseResult { IsSuccess = false, Message = "  مدينة الي  غير موجود" };
            model.CityToName = cityTo.Name;

            if(model.CompanyId > 0)
            {
               var Company = await UnitOFWork.Repository<Company>()
                              .Where(e => e.Id == model.CompanyId).FirstOrDefaultAsync();
                if(Company == null)
                return new ResponseResult { IsSuccess = false, Message = "  الشركة الي  غير موجود" };
                model.CompanyName = Company.Name;

            }

            model.CreatedById = Id;
            model.CreatedByName = Name;

            await UnitOFWork.Repository<Bookings>().AddAsync(model);
            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Add Success",
                Obj = model
            };
        }
        public async Task<ResponseResult> GetAll()
        {
            var All = await UnitOFWork.Repository<Bookings>().ToListAsync();
            if (All == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };
            return new ResponseResult { IsSuccess = true, Message = "none", Obj = All };
        }
        public async Task<ResponseResult> Delete(int id)
        {
            if (id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };

            var modelExist = await UnitOFWork.Repository<Bookings>().
                Where(e => e.Id == id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            var CompleteBookings = await UnitOFWork.Repository<CompleteBookings>().
                   Where(e => e.BookingsId == modelExist.Id).FirstOrDefaultAsync();
            if (CompleteBookings == null)
                return new ResponseResult { IsSuccess = false, Message = "لا يمكن حذف الحجز احذف الاعتماد اولا" };

            var i = await UnitOFWork.Repository<Bookings>().DeleteAsync(modelExist.Id);
            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Delete Success",
                Obj = modelExist.Id
            };
        }
        public async Task<ResponseResult> Update(Bookings model)
        {

            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.Id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };


            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Null" };

            if (model.ClientId <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل العميل  " };

            if (model.ClientPhone == "" || model.ClientPhone == null)
                return new ResponseResult { IsSuccess = false, Message = "ادخل رقم العميل  " };

            if (model.Date == null)
                return new ResponseResult { IsSuccess = false, Message = "ادخل  تاريخ الرحله  " };

            if (model.AddressFrom == null || model.AddressFrom == "")
                return new ResponseResult { IsSuccess = false, Message = "ادخل عنوان الرحله من " };

            if (model.AddressTo == null || model.AddressTo == "")
                return new ResponseResult { IsSuccess = false, Message = "ادخل عنوان الرحله الي " };

            if (model.CityFromId <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل المحافظة من " };

            if (model.CityToId <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل المحافظة الي " };

            if (model.TravelType <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل  نوع الرحله " };

  
            var client = await UnitOFWork.Repository<Clients>()
                .Where(e => e.Id == model.ClientId).FirstOrDefaultAsync();
            if (client == null)
                return new ResponseResult { IsSuccess = false, Message = "   العميل غير موجود" };
            model.ClientName = client.Name;

            var cityFrom = await UnitOFWork.Repository<City>()
                .Where(e => e.Id == model.CityFromId).FirstOrDefaultAsync();
            if (cityFrom == null)
                return new ResponseResult { IsSuccess = false, Message = "  مدينة من  غير موجود" };
            model.CityFromName = cityFrom.Name;


            var cityTo = await UnitOFWork.Repository<City>()
              .Where(e => e.Id == model.CityToId).FirstOrDefaultAsync();
            if (cityTo == null)
                return new ResponseResult { IsSuccess = false, Message = "  مدينة الي  غير موجود" };
            model.CityToName = cityTo.Name;


            var modelExist = await UnitOFWork.Repository<Bookings>().
                  Where(e => e.Id == model.Id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            if (model.CompanyId > 0)
            {
                var Company = await UnitOFWork.Repository<Company>()
                               .Where(e => e.Id == model.CompanyId).FirstOrDefaultAsync();
                if (Company == null)
                    return new ResponseResult { IsSuccess = false, Message = "  الشركة الي  غير موجود" };
                model.CompanyName = Company.Name;

            }

            model.LastModifiedDate = DateTime.Now;
            model.ModifyById = Id;
            model.ModifyByName = Name;
            model.ModifyCount = modelExist.ModifyCount + 1;
            model.Completed = modelExist.Completed;


            var MapModel = _mapper.Map(model, modelExist);
            var i = await UnitOFWork.Repository<Bookings>().UpdateAsync(MapModel);
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
