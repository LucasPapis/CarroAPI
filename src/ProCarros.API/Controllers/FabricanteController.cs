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
    public class FabricanteController : ControllerBase
    {
        private readonly IFabricantesService _fabricantesService;
        public FabricanteController(IFabricantesService fabricantesService)
        {
            _fabricantesService = fabricantesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var fabricantes = await _fabricantesService.GetFabricantesAsync();
                if(fabricantes == null) return NoContent();  
                return Ok(fabricantes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar os fabricantes. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var fabricantes = await _fabricantesService.GetFabricanteIdAsync(id);
                if(fabricantes == null) return NotFound("fabricante especificado não foi encontrado");
                return Ok(fabricantes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar os fabricantes. Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(FabricanteDto model)
        {
            try
            {
                var fabricantes = await _fabricantesService.AddFabricantes(model);
                if (fabricantes == null) return NoContent();
                return Ok(fabricantes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar adicionar o fabricante. Erro: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FabricanteDto model)
        {
            try
            {
                var fabricante = await _fabricantesService.UpdateFabricante(id, model);
                if (fabricante == null) return NoContent();
                return Ok(fabricante);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar atualizar o fabricante. Erro: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var fabricante = await _fabricantesService.GetFabricanteIdAsync(id);
                if(fabricante == null) return NoContent();
                return await _fabricantesService.DeleteFabricantes(id)? Ok("Deletado"): 
                throw new Exception("Erro desconhecido");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar Deletar o fabricante. Erro: {ex.Message}");
            }
        }
    }
}
