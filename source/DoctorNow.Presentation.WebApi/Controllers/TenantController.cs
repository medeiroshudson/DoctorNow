using MediatR;
using Microsoft.AspNetCore.Mvc;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Application.Features.Tenants.Queries;
using DoctorNow.Application.Features.Tenants.Commands;
using DoctorNow.Application.Features.Tenants.Contracts;
using DoctorNow.Domain.Tenants;
using TenantMapper = DoctorNow.Application.Features.Tenants.TenantMapper;

namespace DoctorNow.Presentation.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TenantController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllTenantsQuery();
        
        var result = await sender.Send(query);
        
        if (result.IsFailure) return HandleErrorResult(result.Error);

        var mapped = new TenantMapper()
            .MapToResponseCollection(result.Data!);

        return StatusCode(StatusCodes.Status200OK, mapped);
    }
    
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetTenantByIdQuery(id);

        var result = await sender.Send(query);
        
        if (result.IsFailure) return HandleErrorResult(result.Error);

        var mapped = new TenantMapper()
            .MapToResponse(result.Data!);

        return StatusCode(StatusCodes.Status200OK, mapped);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTenantRequest request)
    {
        var command = new CreateTenantCommand(request.Name, request.DocumentNumber);
        
        var result = await sender.Send(command);
     
        if (result.IsFailure) return HandleErrorResult(result.Error);

        var mapped = new TenantMapper()
            .MapToResponse(result.Data!);

        return StatusCode(StatusCodes.Status201Created, mapped);
    }
    
    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateTenantRequest request)
    {
        var command = new UpdateTenantCommand(
            id, request.Name, request.DocumentNumber, request.Status);
        
        var result = await sender.Send(command);
        
        if (result.IsFailure) return HandleErrorResult(result.Error);

        var mapped = new TenantMapper()
            .MapToResponse(result.Data!);

        return StatusCode(StatusCodes.Status200OK, mapped);
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
            TenantErrors.NotFoundErrorCode => StatusCode(StatusCodes.Status404NotFound, error),
            TenantErrors.DocumentNumberNotUniqueErrorCode => StatusCode(StatusCodes.Status409Conflict, error),
            _ => StatusCode(StatusCodes.Status400BadRequest, error),
        };
    }
}