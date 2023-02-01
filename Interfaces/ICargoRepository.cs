using Itzz.DTO;
using Itzz.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Itzz.Interfaces;

public interface ICargoRepository
{ 
    Task<PagedList<CargoDto>> GetCargoAsync(CargoPagedParams cargoPagedParams);
    void AddNewCargo(CargoDto cargoDto);
    Task<ActionResult> UpdateCargo();
    Task<ActionResult> DeleteCargo();
    Task<bool> SaveAllAsync();
}