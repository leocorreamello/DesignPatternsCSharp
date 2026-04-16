namespace Alura.Adopet.Console;

[DocComando(instrucao: "show",
            documentacao: "adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
internal class Show
{
    public void ExibirConteudoDoArquivo(string caminhoDoArquivoDeImportacao)
    {
        LeitorDeArquivo leitor = new LeitorDeArquivo();
        List<Pet> pets = leitor.RealizaLeitura(caminhoDoArquivoDeImportacao);
        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }
}
