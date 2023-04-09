using Application.Features.Addresses.Commands.Add;
using Application.Features.Addresses.Commands.Delete;
using Application.Features.Addresses.Commands.HardDelete;
using Application.Features.Addresses.Commands.Update;
using Application.Features.Addresses.Queries.GetAll;
using Application.Features.Addresses.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class AddressesController:ApiControllerBase
{
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync(AddressAddCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPost("Delete")]
    public async Task<IActionResult> DeleteAsync(AddressDeleteCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    [HttpPost("HardDelete")]
    public async Task<IActionResult> HardDeleteAsync(AddressHardDeleteCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync(AddressUpdateCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAllAsync(AddressGetAllQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpPost("GetById")]
    public async Task<IActionResult> GetByIdAsync(AddressGetByIdQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetAllAsync(string userId)
    {
        return Ok(await Mediator.Send(new AddressGetAllQuery(userId,null)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await Mediator.Send(new AddressGetByIdQuery(id,null)));
    }
    
}