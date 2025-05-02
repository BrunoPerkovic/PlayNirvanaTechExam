
namespace PlayNirvanaTechExam.RequestFeatures;

public class RequestParameters
{
    private string? _serachTerm;

    public string? SearchTerm
    {
        get => _serachTerm;
        set => _serachTerm = value?.Trim()
            .ToLower();
    }
}