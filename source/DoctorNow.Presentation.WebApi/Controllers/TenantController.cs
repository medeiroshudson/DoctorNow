using MediatR;
using Microsoft.AspNetCore.Mvc;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Application.Tenants.Queries;
using DoctorNow.Application.Tenants.Commands;
using DoctorNow.Presentation.Common.Contracts.Tenants;

namespace DoctorNow.Presentation.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TenantController(ISender sender, ILogger<TenantController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllTenantsQuery();
        
        var result = await sender.Send(query);
        
        return result.IsSuccess ? StatusCode(StatusCodes.Status200OK, result.Value) : HandleErrorResult(result.Error);
    }
    
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetTenantByIdQuery(id);

        var result = await sender.Send(query);

        return result.IsSuccess ? StatusCode(StatusCodes.Status200OK, result.Value) : HandleErrorResult(result.Error);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTenantRequest request)
    {
        var command = new CreateTenantCommand(request.Name, request.DocumentNumber);
        
        var result = await sender.Send(command);
        
        return result.IsSuccess ? StatusCode(StatusCodes.Status201Created, result.Value) : HandleErrorResult(result.Error);
    }
    
    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateTenantRequest request)
    {
        var command = new UpdateTenantCommand(id, request.Name, request.DocumentNumber, request.Status);
        
        var result = await sender.Send(command);
        
        return result.IsSuccess ? StatusCode(StatusCodes.Status200OK, result.Value) : HandleErrorResult(result.Error);
    }
    
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteTenantCommand(id);
        
        var result = await sender.Send(command);
        
        return result.IsSuccess ? StatusCode(StatusCodes.Status204NoContent) : HandleErrorResult(result.Error);
    }

    private ObjectResult HandleErrorResult(Error error)
    {
        return error.Code switch
        {
            "Tenant.NotFound" => StatusCode(StatusCodes.Status404NotFound, error),
            "Tenant.DocumentNumberNotUnique" => StatusCode(StatusCodes.Status409Conflict, error),
            _ => StatusCode(StatusCodes.Status400BadRequest, error),
        };
    }
}