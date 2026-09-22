using TaskPulse.Api.Models.Enums;

namespace TaskPulse.Api.Models.Entities;

public class TaskItem
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public Enums.TaskStatus Status { get; set; }
    public TaskPriority Priority { get; set; }
    public Guid? AssignedUserId { get; set; }
    public DateTime? DueDateUtc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? DeletedAtUtc { get; set; }
    public Project? Project { get; set; }
    public User? AssignedUser { get; set; }
}
