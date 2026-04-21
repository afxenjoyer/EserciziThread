namespace Es._7;

internal class Program
{
    static int Contatore = 0;
    static object lockIncremento = new object();

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
            lock (lockIncremento)
            {
                Contatore++;
            }
        }
    }
}