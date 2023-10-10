using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Common.Mapping;
using Users.Domain;

namespace Users.Application.Users.Queries.GetUserList
{
    public class UserLookupDto : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<User, UserLookupDto>()
                .ForMember(userVm => userVm.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.UserName,
                    opt => opt.MapFrom(user => user.UserName));
        }
    }
}
