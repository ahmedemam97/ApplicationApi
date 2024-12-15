
using Application.Interfaces;
using Application.Interfaces.Expeneds;
using Domain.Dto;
using Domain.Entities.Expened;

namespace Application.Implement.Expeneds
{
    public class ExpenedService : IExpenedService
    {
        private readonly IUnitOfWork UnitOFWork;

        public ExpenedService(IUnitOfWork unitOFWork)
        {
            UnitOFWork = unitOFWork;
        }

        public async Task<ResponseResult> Create(Expened model)
        {

            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Null" };

            if (model.Amount <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل قيمة المصروف" };
  

            await UnitOFWork.Repository<Expened>().AddAsync(model);
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
            
            var All = await UnitOFWork.Repository<Expened>().ToListAsync();
            if (All == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };
            return new ResponseResult { IsSuccess = true, Message = "none", Obj = All };
        }

        public async Task<ResponseResult> Update(Expened model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Null" };

            await UnitOFWork.Repository<Expened>().UpdateAsync(model);

            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Add Success",
                Obj = model
            };
        }
    }
}
