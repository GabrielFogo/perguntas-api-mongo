using MongoDB.Driver;

namespace perguntas_api_mongo.Data;

public interface IPerguntaContext
{
    public IMongoCollection<Pergunta> Perguntas { get; set; }
}