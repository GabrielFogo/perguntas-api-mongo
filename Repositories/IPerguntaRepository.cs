namespace perguntas_api_mongo.Repositories;

public interface IPerguntaRepository
{
    public Task<Pergunta> GetPerguntaAsync(string id);
    public Task<IEnumerable<Pergunta>> GetPerguntasAsync();
    public Task<Pergunta> CreatePerguntaAsync(Pergunta pergunta);
    public Task<bool> UpdatePerguntaAsync(Pergunta pergunta);
    public Task<bool> DeletePerguntaAsync(string id);
}