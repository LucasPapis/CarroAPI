using System;
using System.ComponentModel.DataAnnotations;

namespace ProCarros.Domain
{
    public class Carro
    {
        [Key]
        public int Id_carro{ get; set; }
        public string Nm_Carro  { get; set; }
        public DateTime? Dt_Fabricacao { get; set; }
        public string Cor { get; set; }
        public int Qtd_Porta { get; set; }
        public int FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}