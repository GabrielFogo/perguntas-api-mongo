namespace perguntas_api_mongo.Models;

public class Alternativas
{
    public LetrasAlternativas? LetrasAlternativa { get; set; }
    public string? description { get; set; }
    public bool correta { get; set; }
}

