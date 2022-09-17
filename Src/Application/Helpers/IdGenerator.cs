using System.Text;

namespace Application.Helpers;

using Microsoft.AspNetCore.Http;

public class IdGenerator
{
    public static string GenerateCacheKeyFromRequest(HttpRequest request)
    {
        var keyBuilder = new StringBuilder();
        keyBuilder.Append($"{request.Path}"); // save the path
        foreach (var (key, value) in request.Query.OrderBy(x => x.Key)) //ex : pageId=1,sort = title,type : desc,take = 30
            keyBuilder.Append($"|{key}-{value}"); // save query
        return keyBuilder.ToString();
    }
}