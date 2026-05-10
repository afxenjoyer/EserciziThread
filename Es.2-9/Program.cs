internal class Program
{
    static Random _r = new Random();
    public static async Task Main(string[] args)
    {
        // n1, n2 e n3 non sono int, ma sono Task, per ottenere il risultato di un Task si fa "n1.Result". 
        var n1 = DammiUnNumeroAsync();
        var n2 = DammiUnNumeroAsync();
        var n3 = DammiUnNumeroAsync();

        // Aspetta che tutte le funzioni abbiano finito l'esecuzione.
        await Task.WhenAll(n1, n2, n3);

        Console.WriteLine($"La somma dei risultati casuali ({n1.Result} + {n2.Result} + {n3.Result}) è: " +
            $"{n1.Result + n2.Result + n3.Result}");
    }

    public static async Task<int> DammiUnNumeroAsync()
    {
        await Task.Delay(10000);
        return _r.Next(1, 10);
    }
}
