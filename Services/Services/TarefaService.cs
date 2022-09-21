using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.DataBaseConnection;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ApiContext _context;

        public TarefaService(ApiContext apiContext)
        {
            _context = apiContext;
        }

        public void GerarNovasCredenciais(Tarefa tarefa)
        {
            tarefa.Data = DateTime.Now;
        }

        public async Task<Tarefa> CriarTarefa(Tarefa tarefa)
        {
            GerarNovasCredenciais(tarefa);

            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<List<Tarefa>> GetAll()
        {

            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> BuscaTarefaPorId(int id)
        {
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return tarefa;
        }

        public async Task<Tarefa> DeletarPorId(int id)
        {
            var tarefaEncontrada = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (tarefaEncontrada is null)
            {
                return null;
            }
            _context.Tarefas.Remove(tarefaEncontrada);
            await _context.SaveChangesAsync();
            return tarefaEncontrada;
        }

        public async Task<Tarefa> AtualizarPorId(int id, Tarefa tarefa)
        {
            var tarefaEncontrada = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (tarefaEncontrada is null)
            {
                return null;
            }
            tarefaEncontrada.Descricao = tarefa.Descricao;
            tarefaEncontrada.Data = DateTime.Now;
            _context.Entry(tarefaEncontrada).State = EntityState.Modified;
            _context.SaveChanges();
            return tarefaEncontrada;
        }
    }
}
