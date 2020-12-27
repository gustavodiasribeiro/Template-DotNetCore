using System;
using System.Collections.Generic;
using System.Text;
using Template.Aplication.ViewModels;

namespace Template.Aplication.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get();
    }
}
