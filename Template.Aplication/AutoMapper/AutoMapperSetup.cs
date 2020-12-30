using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Aplication.ViewModels;
using Template.Domain.Entities;

namespace Template.Aplication.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain
            CreateMap<UserViewModel, User>();
            #endregion
            #region DomainToViewModel
            CreateMap<User, UserViewModel>();
            #endregion
        }
    }
}
