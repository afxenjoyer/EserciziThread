namespace Es._2_22;

public class Persona
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string NumTelefono { get; set; }

    public Persona(string nome, string cognome, string numTelefono)
    {
        Nome = nome;
        Cognome = cognome;
        NumTelefono = numTelefono;
    }

    public override string ToString()
    {
        return $"{Nome} {Cognome} {NumTelefono}";
    }
}