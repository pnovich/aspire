namespace MyAspireApp.ApiService.Entities;

public class Winner
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public Guid UserId { get; set; }
    
    // public User User { get; set; }
}