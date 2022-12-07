using AutoMapper;
using MyApp.Application.Handlers;
using MyApp.Application.Handlers.Users;
using MyApp.Domain.Entities;

namespace MyApp.Application;
public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<CreateUserHandlerRequest, User>();
		CreateMap<User, CreateUserHandlerResponse>();

		CreateMap<User, ValidateUserHandlerResponse>();
	}
}
