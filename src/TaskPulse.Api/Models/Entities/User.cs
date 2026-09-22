using TaskPulse.Api.Models.Enums;

namespace TaskPulse.Api.Models.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string FullName { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public ICollection<ProjectMember> Memberships { get; set; } = [];
    public  ICollection<TaskItem> AssignedTasks {get; set; } = [];
}
