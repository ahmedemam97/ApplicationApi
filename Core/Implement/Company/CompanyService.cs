﻿using Application.Interfaces;
using Application.Interfaces.Companys;
using AutoMapper;
using Domain.Dto;
using Domain.Entities.Bookings;
using Domain.Entities.Company;
using Domain.Entities.DailyExpenses;
using Domain.Entities.DailyRevenue;
using Domain.Entities.Expenses;
using Domain.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implement.Companys
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork UnitOFWork;
        private IMapper _mapper;
        private JwtHelper _jwtHelper;
        private string Id;
        private string Name;
        public CompanyService(
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
        public async Task<ResponseResult> Create(Company model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Null" };

            if (model.Name == "" || model.Name == null)
                return new ResponseResult { IsSuccess = false, Message = "ادخل اسم الشركة " };

            model.CreatedById = Id;
            model.CreatedByName = Name;

            await UnitOFWork.Repository<Company>().AddAsync(model);
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

            var modelExist = await UnitOFWork.Repository<Company>().
                Where(e => e.Id == id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            var ExpensesDetails = await UnitOFWork.Repository<ExpensesDetails>().
              Where(e => e.CompanyId == modelExist.Id || e.ExpensesId == modelExist.Id).FirstOrDefaultAsync();
            if (ExpensesDetails == null)
                return new ResponseResult { IsSuccess = false, Message = "لا يمكن حذف الشركة لارتباطه بمصروف" };

            var RevenueCompany = await UnitOFWork.Repository<RevenueDetails>().
                 Where(e => e.CompanyId == modelExist.Id || e.RevenueId == modelExist.Id).FirstOrDefaultAsync();
            if (RevenueCompany == null)
                return new ResponseResult { IsSuccess = false, Message = "لا يمكن حذف الشركة لارتباطه بايراد" };

            var Bookings = await UnitOFWork.Repository<Bookings>().
                   Where(e => e.CompanyId == modelExist.Id).FirstOrDefaultAsync();
            if (Bookings == null)
                return new ResponseResult { IsSuccess = false, Message = "لا يمكن حذف الشركة لارتباطه برحله" };


            var i = await UnitOFWork.Repository<Company>().DeleteAsync(modelExist.Id);
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
            var All = await UnitOFWork.Repository<Company>().ToListAsync();
            if (All == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };
            return new ResponseResult { IsSuccess = true, Message = "none", Obj = All };
        }
        public async Task<ResponseResult> Update(Company model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.Id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };

            if (model.Name == "" || model.Name == null)
                return new ResponseResult { IsSuccess = false, Message = "ادخل اسم الشركة " };

            var modelExist = await UnitOFWork.Repository<Company>().
                Where(e => e.Id == model.Id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            model.LastModifiedDate = DateTime.Now;
            model.ModifyById = Id;
            model.ModifyByName = Name;
            model.ModifyCount = modelExist.ModifyCount + 1;

            var MapModel = _mapper.Map(model, modelExist);
            var i = await UnitOFWork.Repository<Company>().UpdateAsync(MapModel);
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
