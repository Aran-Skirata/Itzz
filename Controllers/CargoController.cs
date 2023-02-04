using AutoMapper;
using Itzz.DTO;
using Itzz.Entities;
using Itzz.Interfaces;
using Itzz.Extensions;
using Itzz.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Itzz.Controllers;

public class CargoController : BaseApiController
{
    private readonly ICargoRepository _cargoRepository;

    public CargoController(ICargoRepository cargoRepository)
    {
        _cargoRepository = cargoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CargoDto>>> GetCargoes([FromQuery]CargoPagedParams cargoPagedParams)
    {
        var cargoes = await _cargoRepository.GetCargoAsync(cargoPagedParams);

        Response.AddPaginationHeader(cargoes.CurrentPage,cargoes.TotalPages, cargoes.PageSize, cargoes.TotalCount);

        return Ok(cargoes);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCargo(CargoDto cargoDto)
    {
        _cargoRepository.AddNewCargo(cargoDto);

        if (await _cargoRepository.SaveAllAsync()) return NoContent();
        return BadRequest("Could not save cargo data");
    }
}