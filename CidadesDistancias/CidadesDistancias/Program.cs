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

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), arquivoCaminho);
        string[] distanciasString = File.ReadAllLines(path);

        return distanciasString[0].Split(',').Select(s => Convert.ToInt32(s)).ToArray();
    }

    public static int[][] PreencheDistancias(string? arquivoDistancias)
    { 
        if (arquivoDistancias == null)
            throw new ArgumentException("Arquivo nao existe");

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), arquivoDistancias);
        string[] distanciasString = File.ReadAllLines(path);

        int[][] distancias = new int[distanciasString[0].Split(',').Length][];
        int i = 0;
        foreach (string linha in distanciasString)
        {
            distancias[i] = distanciasString[i].Split(',').Select(s => Convert.ToInt32(s)).ToArray();
            i += 1;
        }
        return distancias;
    }
}

