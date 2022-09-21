using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testes
{
    public class Class1
    {
        [Table("TabelaTarefas")]

        public class Tarefa
        {
            public string Descricao { get; set; }

            public DateTime Data { get; set; }
            
            [Key]
            public int Id { get; set; }
        }
    }
}