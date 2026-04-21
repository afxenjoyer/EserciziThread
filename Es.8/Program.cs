namespace Es._8;

internal class Program
{
    static int Contatore = 0;
    private static SemaphoreSlim semaforo = new SemaphoreSlim(1);

    public static void Main(string[] args)
    {
        Thread t1 = new Thread(() => IncrementaTanteVolte());
        Thread t2 = new Thread(() => IncrementaTanteVolte());

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("Valore contatore:{0}", Contatore);
    }

    public static void IncrementaTanteVolte()
    {
        for (int i = 0; i < 10000000; i++)
        {
            semaforo.Wait();
            Contatore++;
            semaforo.Release();
        }
    }
}