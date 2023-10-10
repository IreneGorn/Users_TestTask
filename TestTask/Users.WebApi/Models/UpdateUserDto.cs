using AutoMapper;
using Users.Application.Common.Mapping;
using Users.Application.Users.Commands.CreateUser;
using Users.Application.Users.Commands.UpdateUser;
using Users.Domain;

namespace Users.WebApi.Models
{
    public class UpdateUserDto : IMapWith<UpdateUserCommand>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Role> Roles { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForMember(userCommand => userCommand.Id,
                    opt => opt.MapFrom(userDto => userDto.Id))
                .ForMember(userCommand => userCommand.UserName,
                    opt => opt.MapFrom(userDto => userDto.UserName))
                .ForMember(userCommand => userCommand.Age,
                    opt => opt.MapFrom(userDto => userDto.Age))
                .ForMember(userCommand => userCommand.Email,
                    opt => opt.MapFrom(userDto => userDto.Email))
                .ForMember(userVm => userVm.Roles,
                    opt => opt.MapFrom(user => user.Roles));
        }
    }
}
