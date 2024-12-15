using Application.Interfaces;
using Application.Interfaces.Citys;
using Application.Interfaces.Clientss;
using AutoMapper;
using Domain.Dto;
using Domain.Entities.Bookings;
using Domain.Entities.City;
using Domain.Entities.Company;
using Domain.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Implement.Citys
{
    public class CityServices: ICityServices
    {
        private readonly IUnitOfWork UnitOFWork;
        private IMapper _mapper;
        private JwtHelper _jwtHelper;
        private string Id;
        private string Name;
        public CityServices(
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


        public async Task<ResponseResult> Create(City model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Null" };

            if (model.Name == "" || model.Name == null)
                return new ResponseResult { IsSuccess = false, Message = "ادخل اسم المدينه " };

            if (model.Hour <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل عدد الساعات  " };

            model.CreatedById = Id;
            model.CreatedByName = Name;

            await UnitOFWork.Repository<City>().AddAsync(model);
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

            var modelExist = await UnitOFWork.Repository<City>().
                Where(e => e.Id == id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            var Bookings = await UnitOFWork.Repository<Bookings>().
              Where(e => e.CityFromId == modelExist.Id).FirstOrDefaultAsync();
            if (Bookings == null)
                return new ResponseResult { IsSuccess = false, Message = "لا يمكن حذف المدينة هناك رحله" };

            var Bookings2 = await UnitOFWork.Repository<Bookings>().
          Where(e => e.CityToId == modelExist.Id).FirstOrDefaultAsync();
            if (Bookings2 == null)
                return new ResponseResult { IsSuccess = false, Message = "لا يمكن حذف المدينة هناك رحله" };


            var i = await UnitOFWork.Repository<City>().DeleteAsync(modelExist.Id);
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
            var All = await UnitOFWork.Repository<City>().ToListAsync();
            if (All == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };
            return new ResponseResult { IsSuccess = true, Message = "none", Obj = All };
        }
        public async Task<ResponseResult> Update(City model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.Id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };

            if (model.Name == "" || model.Name == null)
                return new ResponseResult { IsSuccess = false, Message = "ادخل اسم المدينة " };

            if (model.Hour <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل عدد الساعات  " };

            var modelExist = await UnitOFWork.Repository<City>().
                Where(e => e.Id == model.Id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };


            model.LastModifiedDate = DateTime.Now;
            model.ModifyById = Id;
            model.ModifyByName = Name;
            model.ModifyCount = modelExist.ModifyCount + 1;

            var MapModel = _mapper.Map(model, modelExist);
            var i = await UnitOFWork.Repository<City>().UpdateAsync(MapModel);
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
