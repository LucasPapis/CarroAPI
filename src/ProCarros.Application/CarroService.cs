using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProCarros.Application.Contratos;
using ProCarros.Application.Dtos;
using ProCarros.Domain;
using ProCarros.Persistence.Contratos;

namespace ProCarros.Application
{
    public class CarroService : ICarroService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly ICarroPersistence _carroPersistence;
        private readonly IMapper _mapper;
        public CarroService(IGeralPersistence geralPersistence, ICarroPersistence carroPersistence, IMapper mapper)
        {
            _mapper = mapper;
            _carroPersistence = carroPersistence;
            _geralPersistence = geralPersistence;
        }
        public async Task AddCarros(int fabricanteId, CarroDto model)
        {
            try
            {
                var carro = _mapper.Map<Carro>(model);
                carro.FabricanteId = fabricanteId;
                _geralPersistence.Add<Carro>(carro);
                await _geralPersistence.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<CarroDto[]> SaveCarro(int fabricanteId, CarroDto[] models)
        {
            try
            {
                var carros = await _carroPersistence.GetCarrosByFabricanteIdAsync(fabricanteId);
                if (carros == null) return null;
                foreach (var model in models)
                {
                    if (model.Id_carro == 0)
                    {
                        await AddCarros(fabricanteId, model);
                    }
                    else
                    {
                        var carro = carros.FirstOrDefault(carro => carro.Id_carro == model.Id_carro);
                        model.FabricanteId = fabricanteId;
                        _mapper.Map(model, carro);
                        _geralPersistence.Update<Carro>(carro);
                        await _geralPersistence.SaveChangeAsync();
                    }
                }
                var carroRetorno = await _carroPersistence.GetCarrosByFabricanteIdAsync(fabricanteId);
                return _mapper.Map<CarroDto[]>(carroRetorno);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteCarro(int fabricanteId, int carroId)
        {
            try
            {
                var carro = await _carroPersistence.GetCarroByIdsAsync(fabricanteId, carroId);
                if (carro == null) throw new Exception("Carro a ser deletado não foi encontrado");
                _geralPersistence.Delete<Carro>(carro);
                return await _geralPersistence.SaveChangeAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CarroDto> GetCarroByIdsAsync(int fabricanteId, int carroId)
        {
            try
            {
                var carros = await _carroPersistence.GetCarroByIdsAsync(fabricanteId, carroId);
                if (carros == null) return null;
                var result = _mapper.Map<CarroDto>(carros);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CarroDto[]> GetCarrosByFabricanteIdAsync(int fabricanteId)
        {
            try
            {
                var carros = await _carroPersistence.GetCarrosByFabricanteIdAsync(fabricanteId);
                if (carros == null) return null;
                var result = _mapper.Map<CarroDto[]>(carros);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}