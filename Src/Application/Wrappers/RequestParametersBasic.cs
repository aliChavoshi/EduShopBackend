namespace Application.Wrappers;

public abstract class RequestParametersBasic : PaginationParametersDto
{
    private string _Search { get; set; }
    public TypeSort TypeSort { get; set; } = TypeSort.Desc;
    public int Sort { get; set; } = 1;

    public string Search
    {
        get => _Search;
        set => _Search = value?.ToLower();
    }
}

public enum TypeSort
{
    Desc = 1,
    Asc
}