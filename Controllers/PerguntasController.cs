using Microsoft.AspNetCore.Mvc;
using perguntas_api_mongo.Models;
using perguntas_api_mongo.Repositories;

namespace perguntas_api_mongo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerguntasController : ControllerBase
    {
        private readonly IPerguntaRepository _perguntaRepository;

        public PerguntasController(IPerguntaRepository perguntaRepository)
        {
            _perguntaRepository = perguntaRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pergunta>> Get(string id)
        { 
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("Invalid Id");
                }
                
                var pergunta = await _perguntaRepository.GetPerguntaAsync(id);
                
                return Ok(pergunta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }  
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pergunta>>> Get()
        { 
            try
            {
                var pergunta = await _perguntaRepository.GetPerguntasAsync();
                return Ok(pergunta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }  
        
        [HttpPost]
        public async Task<ActionResult<Pergunta>> Post(Pergunta pergunta)
        { 
            try
            {
                var perguntaCriada = await _perguntaRepository.CreatePerguntaAsync(pergunta);
                return Ok(perguntaCriada);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        
        [HttpPut]
        public async Task<ActionResult<Pergunta>> Put(Pergunta pergunta)
        { 
            try
            {
                var perguntaAtualizada = await _perguntaRepository.UpdatePerguntaAsync(pergunta);
                
                if (perguntaAtualizada)
                    return Ok("Pergunta atualizada com sucesso");
                
                return NotFound("Pergunta nao encontrada ou nao atualizada");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pergunta>> Delete(string id){ 
            try
            {
                var perguntaDeletada = await _perguntaRepository.DeletePerguntaAsync(id);
                if (perguntaDeletada)
                    return Ok("Pergunta deletada com sucesso");
                
                return NotFound("Pergunta nao encontrado ou nao deletada");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        
        [HttpPost]
        [Route("Responder")]
        public async Task<ActionResult<Pergunta>> Responder(string id, LetrasAlternativas letra){ 
            try
            {
                var pergunta = await _perguntaRepository.GetPerguntaAsync(id);
                var alternativaEscolhida = pergunta.Alternativas.FirstOrDefault(a => a.LetrasAlternativa == letra);

                if (alternativaEscolhida!.correta)
                    return Ok("Acertou");
                
                return Ok("Errou");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
