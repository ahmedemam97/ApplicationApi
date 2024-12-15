using Application.Interfaces;
using Application.Interfaces.User;
using AutoMapper;
using Domain.Dto;
using Domain.Dto.User;
using Domain.Entities;
using Domain.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Application.Implement.User
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork UnitOFWork;
        private readonly JwtHelper _jwtHelper;
        private  UserManager<ApplicationUser> _usermanager { get; set; }
        private IMapper _mapper;

        public UserService(
            IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> usermanager,
            JwtHelper jwtHelper,
            IMapper mapper)
        {
            UnitOFWork = unitOfWork;
            _mapper = mapper;
            _usermanager = usermanager;
            _jwtHelper = jwtHelper;
        }
        public async Task<ResponseResult> Register(UserDto model)
        {
            var user = _mapper.Map<ApplicationUser>(model);
            var oldUserEmail = await _usermanager.FindByEmailAsync(model.Email);
            var oldUserName = await _usermanager.FindByNameAsync(model.UserName);

            if (oldUserEmail != null)
                return new ResponseResult { IsSuccess = false, Message = "Email Is Exist", Obj = null };
            if (oldUserName != null)
                return new ResponseResult { IsSuccess = false, Message = "UserName Is Exist", Obj = null };

            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.Id = Guid.NewGuid().ToString();
            user.RoleId = 2;
            user.RoleName = "User";
            //PasswordHasher<ApplicationUser> Hash = new();
            var result = await _usermanager.CreateAsync(user, model.Password);
            if (result.Succeeded == false)
                return new ResponseResult { IsSuccess = false, Message = "Faild To Register", Obj = null };

            await UnitOFWork.CompleteAsync();
            var response = _mapper.Map<UserRes>(user);
            return new ResponseResult { IsSuccess = true, Message = "Register Success", Obj = response };
        }
        public async Task<ResponseResult> Login(UserLoginDto model)
        {
            var user = await _usermanager.FindByEmailAsync(model.Email);
            if (user == null)
                return new ResponseResult { IsSuccess = false, Message = "Wrong Email" };

            // var PasswordSuccess = await _usermanager.CheckPasswordAsync(user, model.Password);
            // if(PasswordSuccess == false)
            if (model.Password != user.Password)
                return new ResponseResult { IsSuccess = false, Message = "Wrong Password" };

            var result = _mapper.Map<UserRes>(user);
            result.AccesToken = _jwtHelper.GenerateJwtToken(user);

            return new ResponseResult { IsSuccess = true, Message = "Success",Obj= result };
        }
        public async Task<ResponseResult> Delete(string id)
        {
            var user = await _usermanager.FindByIdAsync(id);
            if (user == null)
                return new ResponseResult { IsSuccess = false, Message = "User NotFound", Obj = null };

            await _usermanager.DeleteAsync(user);
            await UnitOFWork.CompleteAsync();
            return new ResponseResult { IsSuccess = true, Message = "Delete Success", Obj = user.Id };
        }
        public async Task<ResponseResult> GetAll()
        {
            var Alluser = await _usermanager.Users.ToListAsync();
            if (Alluser == null)
                return new ResponseResult { IsSuccess = false, Message = "Users NotFound", Obj = null };
           
            return new ResponseResult { IsSuccess = true, Message = "Success", Obj = Alluser };
        }
        public async Task<ResponseResult> GetById(string id)
        {
            var user = await _usermanager.FindByIdAsync(id);
            if (user == null)
                return new ResponseResult { IsSuccess = false, Message = "User NotFound", Obj = null };

            return new ResponseResult { IsSuccess = true, Message = "Success", Obj = user };
        }
        public Task<ResponseResult> Update(UserDto model)
        {
            throw new NotImplementedException();
        }
    }
}
