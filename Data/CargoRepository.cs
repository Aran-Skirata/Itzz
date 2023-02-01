using AutoMapper;
using AutoMapper.QueryableExtensions;
using Itzz.DTO;
using Itzz.Entities;
using Itzz.Interfaces;
using MedFiszkiApi.Data;
using MedFiszkiApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Itzz.Data;

public class CargoRepository : ICargoRepository
{
    private readonly IMapper _mapper;
    private readonly DataContext _dataContext;

    public CargoRepository(IMapper mapper, DataContext dataContext)
    {
        _mapper = mapper;
        _dataContext = dataContext;
    }

    public async Task<PagedList<CargoDto>> GetCargoAsync(CargoPagedParams cargoPagedParams)
    {
        var query = _dataContext.Cargoes.Include(c => c.Orders).AsQueryable();

        query = query.Where(c => c.Uuid == cargoPagedParams.Uuid);

        return await PagedList<CargoDto>.CreateAsync(
            query.ProjectTo<CargoDto>(_mapper.ConfigurationProvider).AsNoTracking(),
            cargoPagedParams.PageNumber,
            cargoPagedParams.PageSize);
    }

    public void AddNewCargo(CargoDto cargoDto)
    {
        _dataContext.Cargoes.Add(_mapper.Map<Cargo>(cargoDto));
    }

    public Task<ActionResult> UpdateCargo()
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult> DeleteCargo()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }
}