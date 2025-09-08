namespace MyAspireApp.ApiService.Entities;

public class User
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string AddressCountry { get; set; } = string.Empty;
    public string AddressRegion { get; set; } = string.Empty;
    public string AddressState { get; set; } = string.Empty;
    public string AddressCity { get; set; } = string.Empty;
    public string AddressStreet { get; set; } = string.Empty;
    public string AddressStreet2 { get; set; } = string.Empty;
    public string AddressCode { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
}