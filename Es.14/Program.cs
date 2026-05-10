internal class Program
{
    // Definiamo la variabile volatile, cosi il compilatore genera comportamenti indesiderati.
    private static  volatile bool _fermatiAdesso = false;

    public static void Main(string[] args)
    {
        var t1 = new Thread((() => Program.Worker()));
        t1.Start();

        Thread.Sleep(1000);
        _fermatiAdesso = true;

        t1.Join();
        Console.WriteLine("Finito");
    }

    public static void Worker()
    {
        int i = 0;
        while (true)
        {
            if (_fermatiAdesso == true)
                return;

            Console.WriteLine(i);
            i++;
            Thread.Sleep(200);
        }
    }
}

