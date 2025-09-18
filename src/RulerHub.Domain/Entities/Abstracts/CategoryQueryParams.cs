namespace RulerHub.Domain.Entities.Abstracts;

public record CategoryQueryParams
(
    string? Search,
    string? SortBy,
    bool Descending = false
);
