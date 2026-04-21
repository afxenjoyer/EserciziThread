// Fatto viene stampato dopo l'esecuzione delle due funzioni

var threadA = new Thread(() => A());
var threadB = new Thread(() => B());

threadA.Start();
threadB.Start();

threadA.Join();
threadB.Join();
Console.WriteLine("Fatto");

void A()
{
    for (int i = 0; i < 50; i++)
    {
        Console.WriteLine("Ciao da A");
    }
}

void B()
{
    for (int i = 0; i < 50; i++)
    {
        Console.WriteLine("Ciao da B");
    }
}