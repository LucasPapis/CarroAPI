using System;
using System.ComponentModel.DataAnnotations;
using ProCarros.Domain;

namespace ProCarros.Application.Dtos
{
    public class CarroDto
    {
        [Key]
        public int Id_carro{ get; set; }
        public string Nm_Carro  { get; set; }
        public DateTime? Dt_Fabricacao { get; set; }
        public string Cor { get; set; }
        public int Qtd_Porta { get; set; }
        public int FabricanteId { get; set; }
        public FabricanteDto Fabricante { get; set; }
    }
}