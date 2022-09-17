namespace Application.Wrappers;

public abstract class PaginationParametersDto
{
    private const int _MaxPageSize = 50;
    private int _PageIndex { get; set; } = 1;
    private int _PageSize { get; set; } = 12;

    public int PageSize
    {
        get => _PageSize;
        set => _PageSize = value > _MaxPageSize ? _MaxPageSize : value;
    }

    public int PageIndex
    {
        get => _PageIndex;
        set => _PageIndex = value <= 0 ? 1 : value;
    }
}