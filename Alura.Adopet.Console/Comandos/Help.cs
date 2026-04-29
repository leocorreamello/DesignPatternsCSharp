using System.Reflection;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "help",
            documentacao: "Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando. \n\n" +
                          "adopet help <parametro> ous simplemente adopet help comando que exibe informações de ajuda dos comandos.")]
internal class Help : IComando
{
    public Task ExecutarAsync(string[] args)
    {
        this.ExibirAjuda(caminhoDoArquivoDeImportacao: args);
        return Task.CompletedTask;
    }

    private Dictionary<string, DocComando> docs;

    public Help()
    {
        docs = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetCustomAttributes<DocComando>().Any())
            .Select(t => t.GetCustomAttribute<DocComando>()!)
            .ToDictionary(d => d.Instrucao);
    }

    private void ExibirAjuda(string[] caminhoDoArquivoDeImportacao)
    {
        System.Console.WriteLine("Lista de comandos.");
        if (caminhoDoArquivoDeImportacao.Length == 1)
        {
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");
            foreach (var doc in docs.Values)
            {
                System.Console.WriteLine(doc.Documentacao);
            }
        }
        // exibe o help daquele comando específico
        else if (caminhoDoArquivoDeImportacao.Length == 2)
        {
            string comandoEspecifico = caminhoDoArquivoDeImportacao[1];
            if (docs.ContainsKey(comandoEspecifico))
            {
                var comando = docs[comandoEspecifico];
                System.Console.WriteLine(comando.Documentacao);
            }
        }
    }
}
