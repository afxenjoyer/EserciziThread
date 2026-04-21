int[] v = new int[100];
int[] w = new int[100];
int variabileLock = 0;

var t1 = new Thread((() => Attivita1()));
var t2 = new Thread((() => Attivita2()));

t1.Start();
t2.Start();

t1.Join();
t2.Join();

void Attivita1()
{
    for (int i = 0; i < 100; i++)
    {
        v[i] = Random.Shared.Next(200);
    }

    while (variabileLock == 1) { }

    Interlocked.Increment(ref variabileLock);
    int[] insiemeVettori1 = v.Concat(w).ToArray();
    Interlocked.Decrement(ref variabileLock);

    Console.WriteLine("Il numero minimo tra v è w è {0}", insiemeVettori1.Min());
}

void Attivita2()
{
    for (int i = 0; i < 100; i++)
    {
        w[i] = Random.Shared.Next(200);
    }

    while (variabileLock == 1) { }

    Interlocked.Increment(ref variabileLock);
    int[] insiemeVettori2 = w.Concat(v).ToArray();
    Interlocked.Decrement(ref variabileLock);

    Console.WriteLine("La media dei valori tra v è w è {0}", insiemeVettori2.Average());
}