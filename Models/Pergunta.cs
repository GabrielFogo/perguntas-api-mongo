using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using perguntas_api_mongo.Models;

public class Pergunta
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public string? Description { get; set; }
    public Alternativas[] Alternativas { get; set; } = new Alternativas[5];
}