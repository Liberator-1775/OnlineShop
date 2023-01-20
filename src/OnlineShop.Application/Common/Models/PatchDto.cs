namespace OnlineShop.Application.Common.Models;

public class PatchDto : EntityDto
{
    private HashSet<string> PropertiesInHttpRequest { get; } = new();

    public bool IsFieldPresent(string propertyName)
    {
        return PropertiesInHttpRequest.Contains(propertyName.ToLowerInvariant());
    }

    public void SetHasProperty(string propertyName)
    {
        PropertiesInHttpRequest.Add(propertyName.ToLowerInvariant());
    }
}