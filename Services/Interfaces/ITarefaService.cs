using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITarefaService
    {
        public void GerarNovasCredenciais(Tarefa tarefa);

        public Task<Tarefa> CriarTarefa(Tarefa tarefa);

        public Task<List<Tarefa>> GetAll();

        public Task<Tarefa> BuscaTarefaPorId(int id);

        public Task<Tarefa> DeletarPorId(int id);

        public Task<Tarefa> AtualizarPorId(int id, Tarefa tarefa);
    }
}

