internal class Program
{
    public static async Task Main(string[] args)
    {
        var cts = new CancellationTokenSource();
        
        var task = DoWorkAsync(cts.Token);
        // cts.CancelAfter(2000);

        try
        {
            await task;
        }
        catch (OperationCanceledException e)
        {
            Console.WriteLine("Operazione interrotta");
            return;
        }

        Console.WriteLine("Operazione terminata con successo");
    }

    static async Task DoWorkAsync(CancellationToken token)
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("Lavoro n°{0}", i);
            await Task.Delay(200);
        }
        token.ThrowIfCancellationRequested();
    }
}