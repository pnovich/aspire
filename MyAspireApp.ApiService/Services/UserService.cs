using Microsoft.EntityFrameworkCore;
using MyAspireApp.ApiService.Data;
using MyAspireApp.ApiService.Entities;
using MyAspireApp.ApiService.Models;
using MyAspireApp.ApiService.Models.Responses;


namespace MyAspireApp.ApiService.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<UserResponse>>> GetAllUsers()
    {
        var users = await _context.Users.ToListAsync();
        var userResponses = users.Select(u => new UserResponse
        {
            Id = u.Id,
            CreatedDate = u.CreatedDate,
            UpdatedDate = u.UpdatedDate,
            UserId = u.UserId,
            FirstName = u.FirstName,
            LastName = u.LastName,
            AddressCountry = u.AddressCountry,
            AddressRegion = u.AddressRegion,
            AddressState = u.AddressState,
            AddressCity = u.AddressCity,
            AddressStreet = u.AddressStreet,
            AddressStreet2 = u.AddressStreet2,
            AddressCode = u.AddressCode,
            PhoneNumber = u.PhoneNumber,
            Notes = u.Notes
        }).ToList();

        return new ServiceResponse<List<UserResponse>> { Data = userResponses, Success = true };
    }

    public async Task<ServiceResponse<UserResponse>> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return new ServiceResponse<UserResponse> 
            { 
                Success = false, 
                Message = "User not found" 
            };
        }

        var userResponse = new UserResponse
        {
            Id = user.Id,
            CreatedDate = user.CreatedDate,
            UpdatedDate = user.UpdatedDate,
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            AddressCountry = user.AddressCountry,
            AddressRegion = user.AddressRegion,
            AddressState = user.AddressState,
            AddressCity = user.AddressCity,
            AddressStreet = user.AddressStreet,
            AddressStreet2 = user.AddressStreet2,
            AddressCode = user.AddressCode,
            PhoneNumber = user.PhoneNumber,
            Notes = user.Notes
        };

        return new ServiceResponse<UserResponse> { Data = userResponse, Success = true };
    }

    public async Task<ServiceResponse<UserResponse>> CreateUser(User user)
    {
        user.CreatedDate = DateTime.UtcNow;
        user.UpdatedDate = DateTime.UtcNow;
        user.UserId = Guid.NewGuid();

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var userResponse = new UserResponse
        {
            Id = user.Id,
            CreatedDate = user.CreatedDate,
            UpdatedDate = user.UpdatedDate,
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            AddressCountry = user.AddressCountry,
            AddressRegion = user.AddressRegion,
            AddressState = user.AddressState,
            AddressCity = user.AddressCity,
            AddressStreet = user.AddressStreet,
            AddressStreet2 = user.AddressStreet2,
            AddressCode = user.AddressCode,
            PhoneNumber = user.PhoneNumber,
            Notes = user.Notes
        };

        return new ServiceResponse<UserResponse> { Data = userResponse, Success = true };
    }

    public async Task<ServiceResponse<UserResponse>> UpdateUser(int id, User updatedUser)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return new ServiceResponse<UserResponse> 
            { 
                Success = false, 
                Message = "User not found" 
            };
        }

        user.FirstName = updatedUser.FirstName;
        user.LastName = updatedUser.LastName;
        user.AddressCountry = updatedUser.AddressCountry;
        user.AddressRegion = updatedUser.AddressRegion;
        user.AddressState = updatedUser.AddressState;
        user.AddressCity = updatedUser.AddressCity;
        user.AddressStreet = updatedUser.AddressStreet;
        user.AddressStreet2 = updatedUser.AddressStreet2;
        user.AddressCode = updatedUser.AddressCode;
        user.PhoneNumber = updatedUser.PhoneNumber;
        user.Notes = updatedUser.Notes;
        user.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        var userResponse = new UserResponse
        {
            Id = user.Id,
            CreatedDate = user.CreatedDate,
            UpdatedDate = user.UpdatedDate,
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            AddressCountry = user.AddressCountry,
            AddressRegion = user.AddressRegion,
            AddressState = user.AddressState,
            AddressCity = user.AddressCity,
            AddressStreet = user.AddressStreet,
            AddressStreet2 = user.AddressStreet2,
            AddressCode = user.AddressCode,
            PhoneNumber = user.PhoneNumber,
            Notes = user.Notes
        };

        return new ServiceResponse<UserResponse> { Data = userResponse, Success = true };
    }

    public async Task<ServiceResponse<bool>> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return new ServiceResponse<bool> 
            { 
                Success = false, 
                Message = "User not found" 
            };
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return new ServiceResponse<bool> { Data = true, Success = true };
    }
}