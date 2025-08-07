namespace MyDomain.Models;

public partial class UserFollow
{
    public string Id { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UserId { get; set; } = null!;

    public string FollowingId { get; set; } = null!;

    public virtual User Following { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
