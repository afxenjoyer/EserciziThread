var filaNumeri = new Queue<int>();
var r = new Random();

var threadProduttore = new Thread((() => Produttore()));
threadProduttore.Start();

var threadConsumatore = new Thread(() => Consumatore());
threadConsumatore.Start();

void Produttore()
{
    bool numeroIsZero = false;
    while (!numeroIsZero)
    {
        lock (filaNumeri)
        {
            int numeroProdotto = r.Next(0, 10);

            if (numeroProdotto == 0)
            {
                numeroIsZero = true;
            }

            filaNumeri.Enqueue(numeroProdotto);
            Console.WriteLine("Prodotto numero {0}", numeroProdotto);

            Monitor.Pulse(filaNumeri);
        }
        Thread.Sleep(100);
    }
}

void Consumatore()
{
    bool numeroIsZero = false;
    while (!numeroIsZero)
    {
        while (filaNumeri.Count != 0)
        {
            lock (filaNumeri)
            {
                while (filaNumeri.Count == 0)
                {
                    Monitor.Wait(filaNumeri);
                }

                int numeroConsumato = filaNumeri.Dequeue();
                if (numeroConsumato == 0)
                {
                    numeroIsZero = true;
                }

                Console.WriteLine("Consumato numero {0}", numeroConsumato);
            }
            Thread.Sleep(1000);
        }
    }
}