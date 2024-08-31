using MongoDB.Driver;
using perguntas_api_mongo.Data;

namespace perguntas_api_mongo.Repositories;

public class PerguntaRepository : IPerguntaRepository
{
    private readonly IPerguntaContext _perguntaContext;

    public PerguntaRepository(IPerguntaContext perguntaContext)
    {
        _perguntaContext = perguntaContext;
    }

    public async Task<Pergunta> GetPerguntaAsync(string id)
    {
        return await _perguntaContext.Perguntas.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Pergunta>> GetPerguntasAsync()
    {
        return await _perguntaContext.Perguntas.Find(x => true).ToListAsync();
    }

    public async Task<Pergunta> CreatePerguntaAsync(Pergunta pergunta)
    {
        ArgumentNullException.ThrowIfNull(pergunta);
        
        await _perguntaContext.Perguntas.InsertOneAsync(pergunta);

        return pergunta;
    }

    public async Task<bool> UpdatePerguntaAsync(Pergunta pergunta)
    {
        var updateResult = await _perguntaContext.Perguntas.ReplaceOneAsync(
            filter: p => p.Id == pergunta.Id, replacement: pergunta);

        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeletePerguntaAsync(string id)
    {
        var filter = Builders<Pergunta>.Filter.Eq(p => p.Id, id);
        var deleteResult = await _perguntaContext.Perguntas.DeleteOneAsync(filter);
        
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}