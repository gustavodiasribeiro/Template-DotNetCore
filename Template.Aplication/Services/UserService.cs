using System;
using System.Collections.Generic;
using System.Text;
using Template.Aplication.Interfaces;
using Template.Aplication.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces;
using System.Linq;
using AutoMapper;

namespace Template.Aplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public List<UserViewModel> Get()
        {
            List<UserViewModel> _usersViewModel = new List<UserViewModel>();
            IEnumerable<User> _users = userRepository.GetAll();

            _usersViewModel = mapper.Map<List<UserViewModel>>(_users);

            //_users.ToList().ForEach(x => _usersViewModel.Add(new UserViewModel() 
            //{ 
            //    Id = x.Id,
            //    Name = x.Name,
            //    Email = x.Email
            //}));

            return _usersViewModel;
        }

        public bool Post(UserViewModel userViewModel)
        {
            //User _user = new User
            //{
            //    Id = new Guid(),
            //    Name = userViewModel.Name,
            //    Email = userViewModel.Email
            //};

            User _user = mapper.Map<User>(userViewModel);

            this.userRepository.Create(_user);

            return true;
        }
    }
}
