var threadLambda = new Thread(() => StampaNumero(50));
threadLambda.Start();
threadLambda.Join();
Console.WriteLine("Fatto (Lambda)");

var threadParameter = new Thread(new ParameterizedThreadStart(StampaNumeroObject));
threadParameter.Start(50);
threadParameter.Join();
Console.WriteLine("Fatto (Parameter)");

void StampaNumero(int numero)
{
    for (int i = 1; i <= numero; i++)
    {
        Console.WriteLine(i);
    }
}

void StampaNumeroObject(object numero)
{
    for (int i = 1; i <= (int)numero; i++)
    {
        Console.WriteLine(i);
    }
}