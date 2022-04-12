using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProCarros.Application.Dtos
{
    public class FabricanteDto
    {
        [Key]
        public int Id_Fabricante{ get; set; }
        public string Nm_Fabricante { get; set; }
        public IEnumerable<CarroDto> Carros { get; set; }
    }
}