using Microsoft.EntityFrameworkCore;
using MyAspireApp.ApiService.Data;
using MyAspireApp.ApiService.Entities;
using MyAspireApp.ApiService.Models;
using MyAspireApp.ApiService.Models.Requests;
using MyAspireApp.ApiService.Models.Responses;


namespace MyAspireApp.ApiService.Services;

    public class UserService : IUserService
{
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public User CreateUser(CreateUserRequest dto)
        {
            var user = new User
            {
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                FirstName = dto.FirstName,
                UserId = Guid.NewGuid(),
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                AddressCity = dto.AddressCity,
                AddressRegion = dto.AddressRegion,
                AddressCode = dto.AddressCode,
                AddressState = dto.AddressState,
                AddressCountry = dto.AddressCountry,
                AddressStreet = dto.AddressStreet,
                AddressStreet2 = dto.AddressStreet2,
                Notes = dto.Notes
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
}