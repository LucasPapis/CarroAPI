using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProCarros.Application.Contratos;
using ProCarros.Application.Dtos;

namespace ProCarros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroService _carroService;

        public CarroController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet("{fabricanteId}")]
        public async Task<IActionResult> Get(int fabricanteId)
        {
            try
            {
                var carro = await _carroService.GetCarrosByFabricanteIdAsync(fabricanteId);
                if (carro == null) return NoContent();
                return Ok(carro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar os carros. Erro: {ex.Message}");
            }
        }
        
        [HttpPut("{fabricanteId}")]
        public async Task<IActionResult> Put(int fabricanteId, CarroDto[] models)
        {
            try
            {
                var carro = await _carroService.SaveCarro(fabricanteId, models);
                if (carro == null) return NoContent();
                return Ok(carro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar carro. Erro: {ex.Message}");
            }
        }
        [HttpDelete("{fabricanteId}/{carroId}")]
        public async Task<IActionResult> Delete(int fabricanteId, int carroId)
        {
            try
            {
                var carro = await _carroService.GetCarroByIdsAsync(fabricanteId, carroId);
                if (carro == null) return NoContent();
                return await _carroService.DeleteCarro(carro.FabricanteId, carro.Id_carro) ? Ok("Deletado") :
                throw new Exception("Erro desconhecido");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Deletar o carro. Erro: {ex.Message}");
            }
        }
    }
}
