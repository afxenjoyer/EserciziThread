using System.Diagnostics;

var t1 = new Thread(() =>
{
    Thread.Sleep(3000);
});

var t2 = new Thread(() =>
{
    Thread.Sleep(4000);
});

var t3 = new Thread(() =>
{
    Thread.Sleep(5000);
});

Stopwatch timer = new Stopwatch();

timer.Start();

t1.Start();
t2.Start();
t3.Start();

t1.Join();
t2.Join();
t3.Join();

timer.Stop();
Console.WriteLine("Per fare tutto ci ho messo {0} secondi e {1} millisecondi", timer.Elapsed.Seconds, timer.Elapsed.Milliseconds);