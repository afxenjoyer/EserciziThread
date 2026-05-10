var filaOrdini = new Queue<Ordine>();

var t1 = new Thread((() => Cliente(Ordine.Caffe)));
var t2 = new Thread((() => Cliente(Ordine.Cappuccino)));
var t3 = new Thread((() => Cliente(Ordine.LatteMacchiato)));
var tBarista = new Thread((() => Barista()));

t1.Start();
t2.Start();
t3.Start();
tBarista.Start();

return;

void Cliente(Ordine ordineRichiesto)
{
    for (int i = 0; i < 10; i++)
    {
        lock (filaOrdini)
        {
            filaOrdini.Enqueue(ordineRichiesto);
            Monitor.Pulse(filaOrdini);
        }
        Console.WriteLine("Voglio un {0}", ordineRichiesto);

        Thread.Sleep(500);
    }
}

void Barista()
{
    while (filaOrdini.Count != 0)
    {
        lock (filaOrdini)
        {
            while (filaOrdini.Count == 0)
            {
                Monitor.Wait(filaOrdini);
            }

            var ordine = filaOrdini.Dequeue();
            Console.WriteLine("Servito {0}", ordine);
        }
        Thread.Sleep(800);
    }
}

enum Ordine
{
    Caffe,
    Cappuccino,
    LatteMacchiato
}