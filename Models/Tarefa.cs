using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("TabelaTarefas")]  //Data Anotation
    public class Tarefa
    {
        public string Descricao { get; set; }

        public DateTime Data { get; set; }

        [Key]
        public int Id { get; set; }
    }
}