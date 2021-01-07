using System;
using System.Collections.Generic;
using System.Text;
using Template.Aplication.ViewModels;

namespace Template.Aplication.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get();

        bool Post(UserViewModel userViewModel);

        UserViewModel GetUserById(string id);

        bool Put(UserViewModel userViewModel);

        bool Delete(string id);
    }
}
