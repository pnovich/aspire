using Microsoft.EntityFrameworkCore;
using MyAspireApp.ApiService.Data;
using MyAspireApp.ApiService.Entities;
using MyAspireApp.ApiService.Models.Requests;

namespace MyAspireApp.ApiService.Services;

public class WinnerService : IWinnerService
{
    private readonly AppDbContext _context;

    public WinnerService(AppDbContext context)
    {
        _context = context;
    }

    public Winner CreateWinner(CreateWinnerRequest dto)
    {
        if (!_context.Users.Any(u => u.UserId == dto.UserId))
            throw new ArgumentException("User not found");

        var winner = new Winner
        {
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            UserId = dto.UserId
        };

        _context.Winners.Add(winner);
        _context.SaveChanges();

        return winner;
    }

    public IEnumerable<Winner> GetAllWinners()
    {
        return _context.Winners.ToList();
    }
}
