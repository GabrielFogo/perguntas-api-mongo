using MongoDB.Driver;

namespace perguntas_api_mongo.Data;

public class PerguntasContext : IPerguntaContext
{
    public PerguntasContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Perguntas = database.GetCollection<Pergunta>(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
    }
    
    public IMongoCollection<Pergunta> Perguntas { get; set; }
}