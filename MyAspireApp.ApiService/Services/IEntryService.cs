using Microsoft.EntityFrameworkCore;
using MyAspireApp.ApiService.Data;
using MyAspireApp.ApiService.Entities;
using MyAspireApp.ApiService.Models;
using MyAspireApp.ApiService.Models.Requests;
using MyAspireApp.ApiService.Models.Responses;


namespace MyAspireApp.ApiService.Services;


    public interface IEntryService
    {
        Entry CreateEntry(CreateEntryRequest dto);
        IEnumerable<Entry> GetAllEntries();
    }
