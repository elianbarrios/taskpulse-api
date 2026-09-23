using TaskPulse.Api.Models.Entities;

namespace TaskPulse.Api.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}