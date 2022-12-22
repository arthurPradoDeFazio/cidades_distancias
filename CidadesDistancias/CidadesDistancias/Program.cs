using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace CidadesDistancias;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Entre com o nome do arquivo com as distâncias na área de trabalho entre cidades: ");
        int[][] distancias = PreencheDistancias(Console.ReadLine());

        Console.WriteLine("Entre com o nome do arquivo com o caminho");
        int[] caminho = PreencheCaminho(Console.ReadLine());
       

        int distanciaPercorrida = CalculaDistanciaDoCaminho(caminho, distancias);
        Console.WriteLine($"A distância percorrida foi {distanciaPercorrida}");
    }

    private static int CalculaDistanciaDoCaminho(int[] caminho, int[][] distancias)
    {
        int distancia = 0;
        int anterior = caminho[0] - 1;
        int atual;
        for (int i = 1; i < caminho.Length; i++)
        {
            atual = caminho[i] - 1;
            distancia += distancias[anterior][atual];
            anterior = atual;
        }

        return distancia;
    }

    private static int[] PreencheCaminho(string? arquivoCaminho)
    {
        if (arquivoCaminho == null)
            throw new ArgumentException("Arquivo nao existe");

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            NewLine = Environment.NewLine,
            Delimiter = ","
        };
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), arquivoCaminho);
        using var leitorCsv = new StreamReader(path);
        using var csv = new CsvParser(leitorCsv, config);

        if (!csv.Read())
            throw new ArgumentException("Arquivo vazio!");

        return csv.Record.Select(x => Convert.ToInt32(x)).ToArray();
    }

    public static int[][] PreencheDistancias(string? arquivoDistancias)
    { 
        if (arquivoDistancias == null)
            throw new ArgumentException("Arquivo nao existe");

        var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
            HasHeaderRecord = false,
            NewLine = Environment.NewLine,
            Delimiter = ","
        };
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), arquivoDistancias);
        using var leitorCsv = new StreamReader(path);
        using var csv = new CsvParser(leitorCsv, config);

        if (!csv.Read())
            throw new ArgumentException("Arquivo vazio!");

        int numColunas = csv.Record.Length;
        int[][] distancias = new int[numColunas][];

        for (int i = 0; i < numColunas; i++, csv.Read())
            distancias[i] = csv.Record.Select(x => Convert.ToInt32(x)).ToArray();
        return distancias;
    }

}

