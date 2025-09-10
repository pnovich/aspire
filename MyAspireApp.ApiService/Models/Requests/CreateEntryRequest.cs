namespace MyAspireApp.ApiService.Models.Requests;

public class CreateEntryRequest
{
    public Guid UserId { get; set; }
    public bool IsActive { get; set; }
    public string Notes { get; set; } = string.Empty;
}