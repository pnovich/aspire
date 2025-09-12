using MyAspireApp.ApiService.Entities;
using MyAspireApp.ApiService.Models.Requests;


namespace MyAspireApp.ApiService.Services;

public interface IWinnerService
{
    Winner CreateWinner(CreateWinnerRequest dto);
    IEnumerable<Winner> GetAllWinners();
}