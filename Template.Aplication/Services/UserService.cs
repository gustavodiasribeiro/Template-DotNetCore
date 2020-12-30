using System;
using System.Collections.Generic;
using System.Text;
using Template.Aplication.Interfaces;
using Template.Aplication.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces;
using System.Linq;

namespace Template.Aplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<UserViewModel> Get()
        {
            List<UserViewModel> _usersViewModel = new List<UserViewModel>();
            IEnumerable<User> _users = userRepository.GetAll();
            _users.ToList().ForEach(x => _usersViewModel.Add(new UserViewModel() 
            { 
                Id = x.Id,
                Name = x.Name,
                Email = x.Email
            }));

            return _usersViewModel;
        }

        public bool Post(UserViewModel userViewModel)
        {
            User _user = new User
            {
                Id = new Guid(),
                Name = userViewModel.Name,
                Email = userViewModel.Email
            };

            this.userRepository.Create(_user);

            return true;
        }
    }
}
