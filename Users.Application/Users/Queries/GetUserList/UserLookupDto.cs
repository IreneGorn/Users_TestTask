using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Common.Mapping;
using Users.Application.Users.Queries.GetUserDetails;
using Users.Domain;

namespace Users.Application.Users.Queries.GetUserList
{
    public class UserLookupDto : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(userVm => userVm.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.UserName,
                    opt => opt.MapFrom(user => user.UserName))
                .ForMember(userVm => userVm.Age,
                    opt => opt.MapFrom(user => user.Age))
                .ForMember(userVm => userVm.Email,
                    opt => opt.MapFrom(user => user.Email))
                .ForMember(userVm => userVm.Roles,
                    opt => opt.MapFrom(user => user.Roles));
        }
    }
}
