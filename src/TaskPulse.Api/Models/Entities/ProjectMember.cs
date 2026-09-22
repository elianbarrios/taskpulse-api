using TaskPulse.Api.Models.Enums;

namespace TaskPulse.Api.Models.Entities;

// Clave primaria compuesta: (ProjectId, UserId)
public class ProjectMember
{
    public Guid ProjectId { get; set; }
    public Guid UserId { get; set; }
    public ProjectRole Role { get; set; }
    public DateTime JoinedAtUtc { get; set; }
    public Project? Project { get; set; }
    public User? User { get; set; }
}
