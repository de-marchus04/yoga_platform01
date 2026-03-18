namespace Yoga.Shared.DTOs
{
    public record AdminAuditLogDto(
        Guid Id,
        Guid? AdminUserId,
        string? AdminIdentifier,
        string Action,
        string EntityType,
        Guid? EntityId,
        string Summary,
        string? MetadataJson,
        string? IpAddress,
        DateTime CreatedAt
    );
}