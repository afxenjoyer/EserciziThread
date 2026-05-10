Thread[] threadCuochi = new Thread[10];
Thread[] threadCamerieri = new Thread[2];
var filaPiatti = new Queue<string>();

for (int i = 0; i < 10; i++)
{
    threadCuochi[i] = new Thread((() => Cucina()));
    threadCuochi[i].Start();
}

for (int i = 0; i < 2; i++)
{
    threadCamerieri[i] = new Thread((() => Servi()));
    threadCamerieri[i].Start();
}

foreach (var cuoco in threadCuochi)
{
    cuoco.Join();
}

foreach (var cameriere in threadCamerieri)
{
    cameriere.Join();
}


void Cucina()
{
    for (int i = 0; i < 20; i++)
    {
        lock (filaPiatti)
        {
            filaPiatti.Enqueue($"Piatto {i}");
            Console.WriteLine("Cucinato Piatto {0}", i);
            Monitor.Pulse(filaPiatti);
        }
        Thread.Sleep(1000);
    }
}

void Servi()
{
    while (filaPiatti.Count != 0)
    {
        lock (filaPiatti)
        {
            while (filaPiatti.Count == 0)
            {
                Monitor.Wait(filaPiatti);
            }

            string piatto = filaPiatti.Dequeue();
            Console.WriteLine("Servito {0}", piatto);
        }
        Thread.Sleep(300);
    }
}
