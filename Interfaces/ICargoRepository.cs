using Itzz.DTO;
using MedFiszkiApi.Helpers;
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