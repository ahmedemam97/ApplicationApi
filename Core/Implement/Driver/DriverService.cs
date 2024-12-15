﻿using Application.Implement.Clientss;
using Application.Interfaces;
using Application.Interfaces.Drivers;
using AutoMapper;
using Domain.Dto;
using Domain.Entities.Clients;
using Domain.Entities.Driver;
using Domain.Entities.DriverExpenses;
using Domain.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implement.DriverS
{
    public class DriverService: IDriverService
    {
        private readonly IUnitOfWork UnitOFWork;
        private IMapper _mapper;
        private JwtHelper _jwtHelper;
        private string Id;
        private string Name;
        public DriverService(
            IUnitOfWork unitOfWork,
            JwtHelper jwtHelper,
             IMapper mapper
            )
        {
            UnitOFWork = unitOfWork;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            Id = _jwtHelper.ReadTokenClaim(TokenClaimType.Id);
            Name = _jwtHelper.ReadTokenClaim(TokenClaimType.UserName);
        }

        public async Task<ResponseResult> Create(Driver model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.Name == null || model.Name == "")
                return new ResponseResult { IsSuccess = false, Message = "ادخل اسم السائق" };

            if (model.PhoneNumber == null || model.PhoneNumber == "")
                return new ResponseResult { IsSuccess = false, Message = "ادخل رقم السائق" };

            model.CreatedById = Id;
            model.CreatedByName = Name;

            await UnitOFWork.Repository<Driver>().AddAsync(model);
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

            var modelExist = await UnitOFWork.Repository<Driver>().
                           Where(e => e.Id == id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

           var DriverExpenses =  await UnitOFWork.Repository<DriverExpenses>().
                   Where(e => e.DriverId == id).FirstOrDefaultAsync();

            if (DriverExpenses != null)
                return new ResponseResult { IsSuccess = false, Message = "يجب حذف حساب السائق اولا" };

            var i = await UnitOFWork.Repository<Driver>().DeleteAsync(modelExist.Id);
            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Delete Success",
                Obj = modelExist.Id
            };
        }
        [Authorize]
        public async Task<ResponseResult> GetAll()
        {
            var All = await UnitOFWork.Repository<Driver>().ToListAsync();
            if (All == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };
            return new ResponseResult { IsSuccess = true, Message = "none", Obj = All };
        }
        public async Task<ResponseResult> Update(Driver model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.Id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };

            if (model.Name == null || model.Name == "")
                return new ResponseResult { IsSuccess = false, Message = "ادخل اسم السائق" };

            if (model.PhoneNumber == null || model.PhoneNumber == "")
                return new ResponseResult { IsSuccess = false, Message = "ادخل رقم السائق" };

            var modelExist = await UnitOFWork.Repository<Driver>().
                Where(e => e.Id == model.Id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            model.LastModifiedDate = DateTime.Now;
            model.ModifyById = Id;
            model.ModifyByName = Name;
            model.ModifyCount = modelExist.ModifyCount + 1;

            var MapModel = _mapper.Map(model, modelExist);
            var i = await UnitOFWork.Repository<Driver>().UpdateAsync(MapModel);
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