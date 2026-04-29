using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "show",
            documentacao: "adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
internal class Show : IComando
{
    public Task ExecutarAsync(string[] args)
    {
        this.ExibirConteudoDoArquivo(caminhoDoArquivoDeImportacao: args[1]);
        return Task.CompletedTask;
    }

    private void ExibirConteudoDoArquivo(string caminhoDoArquivoDeImportacao)
    {
        LeitorDeArquivo leitor = new LeitorDeArquivo();
        List<Pet> pets = leitor.RealizaLeitura(caminhoDoArquivoDeImportacao);
        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }
}
