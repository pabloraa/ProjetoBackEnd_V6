using Microsoft.AspNetCore.Mvc;
using Models;
using Recursos;
using Services.Interfaces;

namespace ProjetoBackEnd_V6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Tarefa tarefa)
        {
            if (tarefa is null)
            {
                return NotFound("Tarefa Não Criada");
            }
            var t = await _tarefaService.CriarTarefa(tarefa);

            return Created("Tarefas", t);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var listaDeTarefas = await _tarefaService.GetAll();
            return Ok(listaDeTarefas);
            //return Ok(await _tarefaService.GetAll());
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> BuscarTarefaPorId(int id)
        {
            var tarefaEncontrada = await _tarefaService.BuscaTarefaPorId(id);

            if (tarefaEncontrada is null)
            {
                return NotFound(Mensagens.TarefaNaoEncontrada);
            }
            return Ok(tarefaEncontrada);
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> DeletarPorId(int id)
        {
            var tarefaEncontrada = await _tarefaService.DeletarPorId(id);
            if (tarefaEncontrada is null)
            {
                return NotFound(Mensagens.TarefaNaoEncontrada);
            }

            return Ok(Mensagens.TarefaDeletada);
        }

        [HttpPut]
        [Route("Atualizar/{id}")]
        public async Task<IActionResult> AtualizarPorId(int id, [FromBody] Tarefa tarefa)
        {
            var tarefaEncontrada = await _tarefaService.AtualizarPorId(id, tarefa);
            if (tarefaEncontrada is null)
            {
                return NotFound(Mensagens.TarefaNaoEncontrada);
            }
            return Ok(tarefaEncontrada);
        }
    }
}

