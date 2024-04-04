using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services;

namespace api.src.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();

        }

        public void CreateUser(User user)
        {
            _userRepository.CreateUser(user);

        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }
    }
}