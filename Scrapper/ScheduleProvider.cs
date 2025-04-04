using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Scrapper;

public interface IScheduleProvider
{
    Task<ScheduleData> GetSchedule(ApiData apiData);
}

public class ScheduleProvider : IScheduleProvider
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ScheduleProvider(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ScheduleData> GetSchedule(ApiData apiData)
    {
        var client = _httpClientFactory.CreateClient();
        var path = @"https://app.fitssey.com/swiatyniaduszy/api/v4/private/frontoffice/schedule";
        var body =
            "{\n  \"category\": null,\n  \"startDate\": \"" + GetStartDate() + "\",\n  \"endDate\": \"" + GetEndDate() + "\",\n  \"filters\": null,\n  \"loadFilters\": false\n}";

        var request = new HttpRequestMessage();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiData.Auth);
        request.Headers.Add("X-Lightenbody-Api-Key", apiData.ApiKey);
        request.Headers.Add("X-Lightenbody-Api-Guid", "0A7B60EF-8DF2-A6AF-45C7-35015B59CEA3");
        request.Headers.Add("X-Lightenbody-Api-Source", "lightenbody");
        request.Headers.Add("X-Csrf-Token", apiData.CsrfToken);
        request.Headers.Add("X-Auth", $":{apiData.Auth}");
        request.RequestUri = new Uri(path);
        request.Method = HttpMethod.Post;
        request.Content = new StringContent(body, new MediaTypeHeaderValue("application/json"));
                
        var result = await client.SendAsync(request);
        var schedule = await result.Content.ReadFromJsonAsync<ScheduleData>();

        return schedule;
    }
    
    private string GetStartDate() =>
        DateTime.Now.ToString("yyyy-MM-dd");
    
    private string GetEndDate() =>
        DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd");
    
}