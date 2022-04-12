using System;
using System.Threading.Tasks;
using AutoMapper;
using ProCarros.Application.Contratos;
using ProCarros.Application.Dtos;
using ProCarros.Domain;
using ProCarros.Persistence.Contratos;

namespace ProCarros.Application
{
    public class FabricanteService : IFabricantesService
    {
        private readonly IGeralPersistence _geralPersist;
        private readonly IFabricantePersistence _fabricantePersist;
         private readonly IMapper _mapper;
        public FabricanteService(IGeralPersistence geralPersist, IFabricantePersistence fabricantePersist,
       
        IMapper mapper)
        {
            _mapper = mapper;
            _fabricantePersist = fabricantePersist;
            _geralPersist = geralPersist;

        }
    public async Task<FabricanteDto> AddFabricantes(FabricanteDto model)
    {
        try
        {
            var fabricante = _mapper.Map<Fabricante>(model);
            _geralPersist.Add<Fabricante>(fabricante);
            if (await _geralPersist.SaveChangeAsync())
            {
                var fabricanteRetorno = await _fabricantePersist.GetFabricanteIdAsync(fabricante.Id_Fabricante);
                return _mapper.Map<FabricanteDto>(fabricanteRetorno);
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<FabricanteDto> UpdateFabricante(int id, FabricanteDto model)
    {
        try
        {
            var fabricante = await _fabricantePersist.GetFabricanteIdAsync(id);
            if (fabricante == null) return null;

            model.Id_Fabricante = fabricante.Id_Fabricante;
            _mapper.Map(model, fabricante);

            _geralPersist.Update<Fabricante>(fabricante);

            if (await _geralPersist.SaveChangeAsync())
            {
                var fabricanteRetorno = await _fabricantePersist.GetFabricanteIdAsync(fabricante.Id_Fabricante);
                return _mapper.Map<FabricanteDto>(fabricanteRetorno);
            }
            return null;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteFabricantes(int fabricanteId)
    {
        try
        {
            var fabricante = await _fabricantePersist.GetFabricanteIdAsync(fabricanteId);
            if (fabricante == null) throw new Exception("Fabricante não encontrado para delete.");
            _geralPersist.Delete<Fabricante>(fabricante);
            return await _geralPersist.SaveChangeAsync();
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<FabricanteDto[]> GetFabricantesAsync()
    {
        try
        {
            var fabricante = await _fabricantePersist.GetFabricantesAsync();
            if (fabricante == null) return null;
            var result = _mapper.Map<FabricanteDto[]>(fabricante);
            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<FabricanteDto> GetFabricanteIdAsync(int fabricanteId)
    {
        try
        {
            var fabricante = await _fabricantePersist.GetFabricanteIdAsync(fabricanteId);
            if (fabricante == null) return null;
            var result = _mapper.Map<FabricanteDto>(fabricante);
            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
}