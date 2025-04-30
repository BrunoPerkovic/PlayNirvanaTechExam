using System.Text;

namespace PlayNirvanaTechExam.RequestFeatures;

public class RequestParameters
{
    private const int MaxPageSize = 100;
    public int PageNumber { get; set; } = 1;
    public int _pageSize = 20;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    private string? _serachTerm;

    public string? SearchTerm
    {
        get => _serachTerm;
        set => _serachTerm = value?.Trim()
            .ToLower();
    }

    public string? OrderBy { get; set; }

    public string BuildParamsList()
    {
        var paramsBuilder = new StringBuilder("?");
        paramsBuilder.Append($"PageNumber={PageNumber}&PageSize={PageSize}");

        if (SearchTerm != null)
        {
            paramsBuilder.Append($"&SearchTerm={SearchTerm}");
        }

        if (OrderBy != null)
        {
            paramsBuilder.Append($"&OrderBy={OrderBy}");
        }

        return paramsBuilder.ToString();
    }
}