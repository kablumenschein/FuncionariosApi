using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _04_Domain.Entities
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cargo { get; set; }

        [Required]
        public string Departamento { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Salario { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
