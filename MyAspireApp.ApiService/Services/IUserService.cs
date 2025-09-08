using MyAspireApp.ApiService.Entities;
using MyAspireApp.ApiService.Models;
using MyAspireApp.ApiService.Models.Responses;
using MyAspireApp.ApiService.Data;

namespace MyAspireApp.ApiService.Services;

public interface IUserService
{
    Task<ServiceResponse<List<UserResponse>>> GetAllUsers();
    Task<ServiceResponse<UserResponse>> GetUserById(int id);
    Task<ServiceResponse<UserResponse>> CreateUser(User user);
    Task<ServiceResponse<UserResponse>> UpdateUser(int id, User user);
    Task<ServiceResponse<bool>> DeleteUser(int id);
}