using Newtonsoft.Json;

namespace MyHttpClient.Models;

public class PostService
{
	private readonly HttpClient _httpClient;

	public PostService(HttpClient httpClient)
	{
		_httpClient = httpClient;
		_httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
	}

	public async Task<List<Post>> GetAll()
	{
		var stringResult = await _httpClient.GetStringAsync("/posts");
		return JsonConvert.DeserializeObject<List<Post>>(stringResult);
	}

	public async Task<Post> GetById(int id)
	{
        var stringResult = await _httpClient.GetStringAsync($"/posts/{id}");
        return JsonConvert.DeserializeObject<Post>(stringResult);
    }
}
