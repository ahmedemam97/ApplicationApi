﻿

namespace Domain.Dto.User
{
    public class UserDto
    {
         public string Id { get; set; }


        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        //public int RoleId { get; set; }
        //public string RoleName { get; set; }
        public string AccesToken { get; set; }



    }
}
