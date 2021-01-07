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

            return _usersViewModel;
        }

        public bool Post(UserViewModel userViewModel)
        {
            User _user = mapper.Map<User>(userViewModel);

            this.userRepository.Create(_user);

            return true;
        }

        public UserViewModel GetUserById(string id)
        {
            if (!Guid.TryParse(id, out Guid userID))
                throw new Exception("UserId is not Valid!!");

            User _user = this.userRepository.Find(x => x.Id == userID && !x.IsDeleted);

            if (_user == null)
                throw new Exception("User is not found!!!");

            return mapper.Map<UserViewModel>(_user);
        }

        public bool Put(UserViewModel userViewModel)
        {
            User _user = this.userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);

            if (_user == null)
                throw new Exception("User is not found!!!");

            _user = mapper.Map<User>(userViewModel);

            this.userRepository.Update(_user);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid userID))
                throw new Exception("UserId is not Valid!!");

            User _user = this.userRepository.Find(x => x.Id == userID && !x.IsDeleted);

            if (_user == null)
                throw new Exception("User is not found!!!");

            return this.userRepository.Delete(_user);
        }
    }
}
