using BLL.Services.Dto;
using DAL.Repository;
using MyMessenger.Models;

namespace BLL.Services;

public class UserService:Service<User, UserDto>
{
    public UserService(IRepository<User> repository) : base(repository)
    {
    }
}