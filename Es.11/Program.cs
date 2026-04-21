internal class Program
{
    public static void Main(string[] args)
    {
        var t1 = new Thread(() => ProcessoInfinito());
        t1.IsBackground = true;

        var t2 = new Thread(() => ProcessoBreve());
        t2.IsBackground = false;

        t1.Start();
        t2.Start();

        // Il programma si ferma solo se il thread di foreground esegue un operazione join
        t2.Join();
    }

    static void ProcessoInfinito()
    {
        int i = 0;
        while (true)
        {
            Console.WriteLine(i);
            i++;
            Thread.Sleep(300);
        }
    }

    static void ProcessoBreve()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(300);
        }
    }
}