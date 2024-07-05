namespace DWX2024.Infrastructure.DTOs;

public record UserDto(
    string UNumber, string? Username, string? Firstname, string? Lastname,
    string? Email, string? Culture, string? Status, IEnumerable<PlantDto>? Plants, IEnumerable<PermissionDto>? Permissions);

public record PlantDto(string Code);

public record PermissionDto(string Permission);