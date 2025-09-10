using Microsoft.EntityFrameworkCore;
using MyAspireApp.ApiService.Data;
using MyAspireApp.ApiService.Entities;
using MyAspireApp.ApiService.Models;
using MyAspireApp.ApiService.Models.Requests;
using MyAspireApp.ApiService.Models.Responses;


namespace MyAspireApp.ApiService.Services;


    public class EntryService : IEntryService
    {
        private readonly AppDbContext _context;

        public EntryService(AppDbContext context)
        {
            _context = context;
        }

        public Entry CreateEntry(CreateEntryRequest dto)
        {
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
