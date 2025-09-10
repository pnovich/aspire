using MyAspireApp.ApiService.Entities;
using MyAspireApp.ApiService.Models;
using MyAspireApp.ApiService.Models.Responses;
using MyAspireApp.ApiService.Data;
using MyAspireApp.ApiService.Models.Requests;

namespace MyAspireApp.ApiService.Services;


    public interface IUserService
    {
        User CreateUser(CreateUserRequest dto);
        IEnumerable<User> GetAllUsers();
    }
