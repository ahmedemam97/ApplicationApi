using Application.Interfaces;
using Application.Interfaces.DailyExpensess;
using AutoMapper;
using Domain.Dto;
using Domain.Entities.Company;
using Domain.Entities.CompanyAPP;
using Domain.Entities.DailyExpenses;
using Domain.Entities.Expenses;
using Domain.Helper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;


namespace Application.Implement.DailyExpensess
{
    public class DailyExpensesService : Hub, IDailyExpensesService
    {
        private readonly IHubContext<DailyExpensesService> HubContext;
        private readonly IUnitOfWork UnitOFWork;
        private IMapper _mapper;
        private JwtHelper _jwtHelper;
        private string Id;
        private string Name;
        public DailyExpensesService(
            IUnitOfWork unitOfWork,
            JwtHelper jwtHelper,
             IMapper mapper,
            IStringLocalizer<DailyExpensesService> localizer, IHubContext<DailyExpensesService> hubContext)
        {
            UnitOFWork = unitOfWork;
            HubContext = hubContext;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            Id = _jwtHelper.ReadTokenClaim(TokenClaimType.Id);
            Name = _jwtHelper.ReadTokenClaim(TokenClaimType.UserName);
        }
        public async Task<ResponseResult> GetPageInfo()
        {
            var DailyExpenseslist = await UnitOFWork.Repository<DailyExpenses>()
                  .Where(e=>e.Flag != ExpensesFlag.Driver)
                .Include(e=>e.ExpensesDetails).ToListAsync();
            if (DailyExpenseslist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };

            var  Expenseslist = await UnitOFWork.Repository<Expenses>().ToListAsync();
            if ( Expenseslist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };


            var Companylist = await UnitOFWork.Repository<Company>().ToListAsync();
            if (Companylist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };


            var CompanyAPPlist = await UnitOFWork.Repository<CompanyAPP>().ToListAsync();
            if (CompanyAPPlist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };


            return new ResponseResult { IsSuccess = true, Message = "none", Obj = new {
                DailyExpenseslist,
                Expenseslist,
                Companylist,
                CompanyAPPlist
            } };
        }
        public async Task<ResponseResult> Create(DailyExpensesDto model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            var DailyExpenses = new DailyExpenses();
            DailyExpenses.ExpensesDetails = new List<ExpensesDetails>();

            if (model.ExpensesDay.Count() > 0 && model.ExpensesDay != null)
            {
                foreach (var item in model.ExpensesDay)
                {
                    if (item.ExpensesId > 0 && item.Amount > 0)
                    {
                        var Expenses = await UnitOFWork.Repository<Expenses>()
                              .Where(e => e.Id == item.ExpensesId).FirstOrDefaultAsync();
                        if (Expenses == null)
                            return new ResponseResult { IsSuccess = false, Message = "المصروف غير موجود" };

                        var ExpensesDay = new ExpensesDetails()
                        {
                            Date = model.Date,
                            Amount = item.Amount,
                            CreatedById = Id,
                            CreatedByName = Name,
                            CreatedDate = DateTime.Now,
                            ExpensesId = Expenses.Id,
                            Flag = ExpensesFlag.Day,
                            Name = Expenses.Name,
                        };
                        DailyExpenses.ExpensesDetails.Add(ExpensesDay);
                    }
                }

            }

            if (model.ExpensesMonth.Count() > 0 && model.ExpensesMonth != null)
            {
                foreach (var item in model.ExpensesMonth)
                {
                    if (item.ExpensesId > 0 && item.Amount > 0)
                    {
                        var Expenses = await UnitOFWork.Repository<Expenses>()
                          .Where(e => e.Id == item.ExpensesId).FirstOrDefaultAsync();
                        if (Expenses == null)
                            return new ResponseResult { IsSuccess = false, Message = "المصروف غير موجود" };

                        var ExpensesMonth = new ExpensesDetails()
                        {
                            Date = model.Date,
                            Amount = item.Amount,
                            CreatedById = Id,
                            CreatedByName = Name,
                            CreatedDate = DateTime.Now,
                            ExpensesId = Expenses.Id,
                            Flag = ExpensesFlag.Month,
                            Name = Expenses.Name,
                        };
                        DailyExpenses.ExpensesDetails.Add(ExpensesMonth);

                    }
                }
            }

            if (model.ExpensesCompany.Count() > 0 && model.ExpensesCompany != null)
            {
                foreach (var item in model.ExpensesCompany)
                {
                    if (item.ExpensesId > 0 && item.Amount > 0)
                    {
                        var Company = await UnitOFWork.Repository<Company>()
                                .Where(e => e.Id == item.ExpensesId).FirstOrDefaultAsync();
                        if (Company == null)
                            return new ResponseResult { IsSuccess = false, Message = "المصروف غير موجود" };

                        var ExpensesCompany = new ExpensesDetails()
                        {
                            Date = model.Date,
                            Amount = item.Amount,
                            CreatedById = Id,
                            CreatedByName = Name,
                            CreatedDate = DateTime.Now,
                            CompanyId = Company.Id,
                            Flag = ExpensesFlag.Company,
                            Name = Company.Name,
                        };
                        DailyExpenses.ExpensesDetails.Add(ExpensesCompany);
                    }
                }
            }

            if (model.ExpensesApp.Count() > 0 && model.ExpensesApp != null)
            {
                foreach (var item in model.ExpensesApp)
                {
                    if (item.ExpensesId > 0 && item.Amount > 0)
                    {
                        var ExpensesCompanyAPP = await UnitOFWork.Repository<CompanyAPP>()
                          .Where(e => e.Id == item.ExpensesId).FirstOrDefaultAsync();
                        if (ExpensesCompanyAPP == null)
                            return new ResponseResult { IsSuccess = false, Message = "المصروف غير موجود" };

                        var ExpensesApp = new ExpensesDetails()
                        {
                            Date = model.Date,
                            Amount = item.Amount,
                            CreatedById = Id,
                            CreatedByName = Name,
                            CreatedDate = DateTime.Now,
                            AppId = ExpensesCompanyAPP.Id,
                            Flag = ExpensesFlag.App,
                            Name = ExpensesCompanyAPP.Name,
                        };
                        DailyExpenses.ExpensesDetails.Add(ExpensesApp);
                    }
                }
            }

            DailyExpenses.Date = model.Date;
            DailyExpenses.NetTotal = DailyExpenses.ExpensesDetails.Sum(e => e.Amount);
            DailyExpenses.CreatedById = Id;
            DailyExpenses.CreatedByName = Name;

            if(DailyExpenses.NetTotal == 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل مصروف واحد علي الاقل" };

            await UnitOFWork.Repository<DailyExpenses>().AddAsync(DailyExpenses);
            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Add Success",
                Obj = DailyExpenses
            };
        }
        public async Task<ResponseResult> Delete(int id)
        {
            if (id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };
            var modelExist = await UnitOFWork.Repository<DailyExpenses>().
                           Where(e => e.Id == id)                      
                           .Include(e=> e.ExpensesDetails).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            var i3 = await UnitOFWork.Repository<DailyExpenses>().DeleteAsync(modelExist.Id);

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
            var All = await UnitOFWork.Repository<DailyExpenses>().ToListAsync();
            if (All == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };

            var Expenseslist = await UnitOFWork.Repository<Expenses>().ToListAsync();
            if (Expenseslist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };

         

            return new ResponseResult { IsSuccess = true, Message = "none", Obj = All };
        }
        public async Task<ResponseResult> Update(DailyExpensesDto model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.Id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };

            var modelExist = await UnitOFWork.Repository<DailyExpenses>().
                Where(e => e.Id == model.Id)
                .Include(e=>e.ExpensesDetails).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };


            UnitOFWork.Repository<ExpensesDetails>().DeleteRange(modelExist.ExpensesDetails);
            modelExist.NetTotal = 0;

            if (model.ExpensesDay.Count() > 0 && model.ExpensesDay != null)
            {
                foreach (var item in model.ExpensesDay)
                {
                    if (item.ExpensesId > 0 && item.Amount > 0)
                    {
                        var Expenses = await UnitOFWork.Repository<Expenses>()
                              .Where(e => e.Id == item.ExpensesId).FirstOrDefaultAsync();
                        if (Expenses == null)
                            return new ResponseResult { IsSuccess = false, Message = "المصروف غير موجود" };

                        var ExpensesDay = new ExpensesDetails()
                        {
                            Date = model.Date,
                            Amount = item.Amount,
                            CreatedById = Id,
                            CreatedByName = Name,
                            CreatedDate = DateTime.Now,
                            ExpensesId = item.ExpensesId,
                            Flag = ExpensesFlag.Day,
                            Name = Expenses.Name,
                        };
                        modelExist.ExpensesDetails.Add(ExpensesDay);
                    }
                }

            }

            if (model.ExpensesMonth.Count() > 0 && model.ExpensesMonth != null)
            {
                foreach (var item in model.ExpensesMonth)
                {
                    if (item.ExpensesId > 0 && item.Amount > 0)
                    {
                        var Expenses = await UnitOFWork.Repository<Expenses>()
                          .Where(e => e.Id == item.ExpensesId).FirstOrDefaultAsync();
                        if (Expenses == null)
                            return new ResponseResult { IsSuccess = false, Message = "المصروف غير موجود" };

                        var ExpensesMonth = new ExpensesDetails()
                        {
                            Date = model.Date,
                            Amount = item.Amount,
                            CreatedById = Id,
                            CreatedByName = Name,
                            CreatedDate = DateTime.Now,
                            ExpensesId = item.ExpensesId,
                            Flag = ExpensesFlag.Month,
                            Name = Expenses.Name,
                        };
                        modelExist.ExpensesDetails.Add(ExpensesMonth);

                    }
                }
            }

            if (model.ExpensesCompany.Count() > 0 && model.ExpensesCompany != null)
            {
                foreach (var item in model.ExpensesCompany)
                {
                    if (item.ExpensesId > 0 && item.Amount > 0)
                    {
                        var Company = await UnitOFWork.Repository<Company>()
                                .Where(e => e.Id == item.ExpensesId).FirstOrDefaultAsync();
                        if (Company == null)
                            return new ResponseResult { IsSuccess = false, Message = "المصروف غير موجود" };

                        var ExpensesCompany = new ExpensesDetails()
                        {
                            Date = model.Date,
                            Amount = item.Amount,
                            CreatedById = Id,
                            CreatedByName = Name,
                            CreatedDate = DateTime.Now,
                            CompanyId = Company.Id,
                            Flag = ExpensesFlag.Company,
                            Name = Company.Name,
                        };
                        modelExist.ExpensesDetails.Add(ExpensesCompany);
                    }
                }
            }

            if (model.ExpensesApp.Count() > 0 && model.ExpensesApp != null)
            {
                foreach (var item in model.ExpensesApp)
                {
                    if (item.ExpensesId > 0 && item.Amount > 0)
                    {
                        var ExpensesCompanyAPP = await UnitOFWork.Repository<CompanyAPP>()
                          .Where(e => e.Id == item.ExpensesId).FirstOrDefaultAsync();
                        if (ExpensesCompanyAPP == null)
                            return new ResponseResult { IsSuccess = false, Message = "المصروف غير موجود" };

                        var ExpensesApp = new ExpensesDetails()
                        {
                            Date = model.Date,
                            Amount = item.Amount,
                            CreatedById = Id,
                            CreatedByName = Name,
                            CreatedDate = DateTime.Now,
                            AppId = ExpensesCompanyAPP.Id,
                            Flag = ExpensesFlag.App,
                            Name = ExpensesCompanyAPP.Name,
                        };
                        modelExist.ExpensesDetails.Add(ExpensesApp);
                    }
                }
            }

            modelExist.LastModifiedDate = DateTime.Now;
            modelExist.ModifyById = Id;
            modelExist.ModifyByName = Name;
            modelExist.ModifyCount = modelExist.ModifyCount + 1;

            var AmountDay = model.ExpensesDay.Sum(e => e.Amount);
            var AmountMonth = model.ExpensesMonth.Sum(e => e.Amount);
            var AmountCompany = model.ExpensesCompany.Sum(e => e.Amount);
            var AmountApp = model.ExpensesApp.Sum(e => e.Amount);


            modelExist.NetTotal = AmountDay + AmountMonth + AmountCompany + AmountApp;

            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Update Success",
                Obj = modelExist
            };
        }
    }
}
