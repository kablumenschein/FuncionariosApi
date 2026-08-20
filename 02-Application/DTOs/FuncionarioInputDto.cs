using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Application.DTOs
{
    public class FuncionarioInputDto
    {
        public string Nome { get; set; }

        [Required]
        public string Cargo { get; set; }

        [Required]
        public decimal Salario { get; set; }

        [Required]
        public string Departamento { get; set; }

    }
}
