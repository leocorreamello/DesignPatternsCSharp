using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Alura.Adopet.Console;

internal class List
{
    HttpClient client;
    public List(HttpClient client)
    {
        this.client = ConfiguraHttpClient("http://localhost:5057");
    }
    public async Task ExibirListaDePets()
    {
        var pets = await ListPetsAsync();
        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }

    HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }

    async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}
