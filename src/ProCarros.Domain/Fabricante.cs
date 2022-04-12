using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProCarros.Domain
{
    public class Fabricante
    {
        [Key]
        public int Id_Fabricante{ get; set; }
        public string Nm_Fabricante { get; set; }
        public IEnumerable<Carro> Carros { get; set; }
    }
}