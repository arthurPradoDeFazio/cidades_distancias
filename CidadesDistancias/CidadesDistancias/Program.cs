namespace CidadesDistancias;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Entre com o número de cidades: ");
        int numeroDeCidades = ColetaInt();

        int[,] distancias = new int[numeroDeCidades, numeroDeCidades];
        PreencheDistancias(distancias);

        int distanciaPercorrida = CalculaDistanciaDoCaminho(distancias);
        Console.WriteLine($"A distância percorrida foi {distanciaPercorrida}");
    }

    private static int CalculaDistanciaDoCaminho(int[,] distancias)
    {
        Console.WriteLine("Entre com o número de cidades em que o caminho vai parar, incluindo as cidades de partida e chegada");
        int cidadesParadas = ColetaInt();

        int distanciaPercorrida = 0;
        Console.WriteLine("Entre com a cidade de partida");
        int anterior, atual;
        anterior = ColetaInt() - 1;
        for (int i = 1; i < cidadesParadas; i++)
        {
            Console.WriteLine("Entre com a próxima cidade");
            atual = ColetaInt() - 1;

            if (atual < anterior)
                distanciaPercorrida += distancias[anterior, atual];
            else
                distanciaPercorrida += distancias[atual, anterior];

            anterior = atual;
        }

        return distanciaPercorrida;
    }

    public static int ColetaInt()
    {
        int i;
        Console.Write("Entre com um número inteiro maior ou igual a zero: ");
        while (!int.TryParse(Console.ReadLine(), out i) || i < 0)
            Console.WriteLine("Entrada inválida, entre com um poisitvo maior ou igual a zero: ");
        return i;
    }

    public static void PreencheDistancias(int[,] distancias)
    {
        for (int i = 0; i < distancias.GetLength(0); i++)
        {
            for (int j = 0; j < i; j++)
            {
                Console.WriteLine($"Entre com a distância entre as cidades {i + 1} e {j + 1}");
                distancias[i, j] = ColetaInt();
            }
        }
    }
}

