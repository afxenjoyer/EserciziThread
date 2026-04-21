var tMarco = new Thread(() => Salutami("Marco"));
var tAnna = new Thread(() => Salutami("Anna"));

tMarco.Start();
tAnna.Start();

tMarco.Join();
tAnna.Join();

Console.WriteLine("Fatto");

void Salutami(string nome)
{
    for (int i = 0; i < 50; i++)
    {
        Console.WriteLine("Ciao {0}", nome);
    }
}
