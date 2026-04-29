using System.Net.Http.Headers;
using Alura.Adopet.Console.Comandos;

Dictionary<string, IComando> comandosDoSistema = new()
{
    { "import", new Import() },
    { "help", new Help() },
    { "show", new Show() },
    { "list", new List() },
};

// cria instância de HttpClient para consumir API Adopet
HttpClient client = ConfiguraHttpClient("http://localhost:5057");
Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0].Trim();
    if (comandosDoSistema.ContainsKey(comando))
    {
        var comandoSelecionado = comandosDoSistema[comando];
        await comandoSelecionado.ExecutarAsync(args);
    }
    else {
        Console.WriteLine("Comando inválido!");
    }
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
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