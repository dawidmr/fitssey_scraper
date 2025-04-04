using System.Text.Json;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Scrapper;

public interface IFrontOfficerovider
{
    Task<ApiData> GetApiData();
}

public class FrontOfficeroviderProvider : IFrontOfficerovider
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string authIndicator = "R6Y34Kq1AA=\"";
    private const string csfrIndicator = "qMysnVInd8=\"";
    private const string apiKeyIndicator = "IquoN9oQiU=\"";
    private const string apiGuidIndicator = "HxhumHyYvZ=\"";
    private const string apiSourceIndicator = "aqEbWIcXoZ=\"";

    public FrontOfficeroviderProvider(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<ApiData> GetApiData()
    {
        var siteContent = await GetFromServer();
        var auth = GetDataFromString(siteContent, authIndicator);
        var csfr = GetDataFromString(siteContent, csfrIndicator);
        var apiKey = GetDataFromString(siteContent, apiKeyIndicator);
        var apiGuid = GetDataFromString(siteContent, apiGuidIndicator);
        var apiSource = GetDataFromString(siteContent, apiSourceIndicator);

        return new(apiKey, apiGuid, apiSource, csfr, auth);
    }

    private async Task<string> GetFromServer()
    {
        var client = _httpClientFactory.CreateClient();
        string path = @"https://app.fitssey.com/swiatyniaduszy/frontoffice";
        var result = await client.GetAsync(path);
        return await result.Content.ReadAsStringAsync();
    }

    private string GetDataFromString(string content, string indicator)
    {
        var startIndex = content.IndexOf(indicator, StringComparison.InvariantCultureIgnoreCase) + indicator.Length;
        var part = content.Substring(startIndex);
        var auth = part.Substring(0, part.IndexOf("\""));

        return auth;
    }
}