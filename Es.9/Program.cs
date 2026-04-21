int[] v = new int[100];
var semaforoV = new SemaphoreSlim(1);

int[] w = new int[100];
var semaforoW = new SemaphoreSlim(1);

var t1 = new Thread((() => Attivita1()));
var t2 = new Thread((() => Attivita2()));

t1.Start();
t2.Start();

t1.Join();
t2.Join();

void Attivita1()
{
    semaforoV.Wait();
    for (int i = 0; i < 100; i++)
    {
        v[i] = Random.Shared.Next(200);
    }
    semaforoV.Release();

    semaforoW.Wait();
    int[] insiemeVettori1 = v.Concat(w).ToArray();
    semaforoW.Release();

    Console.WriteLine("Il numero minimo tra v è w è {0}", insiemeVettori1.Min());
}

void Attivita2()
{
    semaforoW.Wait();
    for (int i = 0; i < 100; i++)
    {
        w[i] = Random.Shared.Next(200);
    }
    semaforoW.Release();

    semaforoV.Wait();
    int[] insiemeVettori2 = w.Concat(v).ToArray();
    semaforoV.Release();

    Console.WriteLine("La media dei valori tra v è w è {0}", insiemeVettori2.Average());
}