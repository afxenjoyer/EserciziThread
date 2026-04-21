// Questo programma stampa un misto tra "Ciao da A"/"Ciao da B" e "Fatto" stampato in punti casuali.
// I thread attivi sono tre: threadA, threadB e il thread Principale.

var threadA = new Thread(() => A());
var threadB = new Thread(() => B());

threadA.Start();
threadB.Start();

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