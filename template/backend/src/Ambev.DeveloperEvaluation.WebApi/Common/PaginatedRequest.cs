namespace Ambev.DeveloperEvaluation.WebApi.Common;

public abstract class PaginatedRequest
{
    const int maxPageSize = 50;
    private int _pageSize = maxPageSize;
    private int _pageNumber = 1;

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = (value >= 1) ? value : _pageNumber;
    }
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
    }
}
