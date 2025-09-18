namespace RulerHub.Domain.Entities.Abstracts;

public record ProductQueryParams
(
    string? Search,
    string? SortBy,
    bool Descending = false,
    int Page = 1,
    int PageSize = 10
);
