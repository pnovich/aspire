using Microsoft.EntityFrameworkCore;
using MyAspireApp.ApiService.Data;
using MyAspireApp.ApiService.Entities;
using MyAspireApp.ApiService.Models;
using MyAspireApp.ApiService.Models.Requests;
using MyAspireApp.ApiService.Models.Responses;
using Microsoft.Extensions.Logging; 


namespace MyAspireApp.ApiService.Services;


    public class EntryService : IEntryService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<EntryService> _logger;

        public EntryService(AppDbContext context)
    {
        _context = context;
    }

        public Entry CreateEntry(CreateEntryRequest dto)
        {
                if (!_context.Users.Any(u => u.UserId == dto.UserId))

        {
           throw new ArgumentException("wrong UserId ");
        }
            var entry = new Entry
            {
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                UserId = dto.UserId,
                IsActive = dto.IsActive,
                Notes = dto.Notes
            };

            _context.Entries.Add(entry);
            _context.SaveChanges();

            return entry;
        }

        public IEnumerable<Entry> GetAllEntries()
        {
            return _context.Entries.ToList();
        }
    }
