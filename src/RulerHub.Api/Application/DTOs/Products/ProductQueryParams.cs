namespace RulerHub.Api.Application.DTOs.Products;

public record ProductQueryParams
(
    string? Search,
    string? SortBy,
    bool Descending = false,
    int Page = 1,
    int PageSize = 10
    );
