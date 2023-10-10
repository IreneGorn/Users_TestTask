﻿using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Users.Application.Common.Mapping;
using Users.Application.Users.Commands.CreateUser;

namespace Users.WebApi.Models
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        [Required]
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        
        public void Mapping(Profile profile) 
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(userCommand => userCommand.UserName,
                    opt => opt.MapFrom(userDto => userDto.UserName))
                .ForMember(userCommand => userCommand.Age,
                    opt => opt.MapFrom(userDto => userDto.Age))
                .ForMember(userCommand => userCommand.Email,
                    opt => opt.MapFrom(userDto => userDto.Email));
        }
    }
}
