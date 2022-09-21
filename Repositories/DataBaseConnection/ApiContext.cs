using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories.DataBaseConnection
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        { }

        public ApiContext()
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
