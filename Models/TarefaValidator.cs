using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TarefaValidator : AbstractValidator<Tarefa>
    {
        public TarefaValidator()
        {
            RuleFor(x => x.Descricao)
                .MaximumLength(80).WithMessage("Não pode ter mais que 80 caracteres")
                .NotEmpty().WithMessage("Não pode ser vazio");
        }
    }
}