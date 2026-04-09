namespace Alura.Adopet.Console;

internal class Show
{
    public void ExibirConteudoDoArquivo(string caminhoDoArquivoDeImportacao)
    {
        using (StreamReader sr = new StreamReader(caminhoDoArquivoDeImportacao))
        {
            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
            while (!sr.EndOfStream)
            {
                // separa linha usando ponto e vírgula
                string[] propriedades = sr.ReadLine().Split(';');
                // cria objeto Pet a partir da separação
                Pet pet = new Pet(Guid.Parse(propriedades[0]),
                propriedades[1],
                TipoPet.Cachorro
                );
                System.Console.WriteLine(pet);
            }
        }
    }
}
