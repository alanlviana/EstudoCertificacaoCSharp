using Curso.Arquitetura.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace certificacao_csharp_pt12.Aula01
{
    class Produto: IValidatableObject
    {
        public int Id { get; set; }
        public int CategoriaID { get; set; }
        public string Nome { get; set; }
        public bool EhValido { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id < 0)
            {
                yield return new ValidationResult("ID do produto deve ser um número positivo.", new[] { "Id" });
            }
            if (string.IsNullOrEmpty(Nome))
            {
                yield return new ValidationResult("O nome do produto deve estar preenchido.", new[] { "Nome" });
            }
        }
    }
}
