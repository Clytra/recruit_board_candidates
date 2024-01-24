namespace RecruitBoard.Services.Candidates.Application.Exceptions;

public class NotFoundException(string entityType, Guid entityId)
    : AppException($"Record of type: {entityType} with ID: {entityId} was not found.")
{
    public override string Code => "not_found_exception";
    public string EntityType { get; } = entityType;
    public Guid EntityId { get; } = entityId;
}