using MediatR;
using Microsoft.AspNetCore.Mvc;
using DoctorNow.Domain.Tenants;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Application.Features.Tenants.Queries;
using DoctorNow.Application.Features.Tenants.Commands;
using DoctorNow.Application.Features.Tenants.Contracts;

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

        return MatchResult(result);
    }
    
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetTenantByIdQuery(id);

        var result = await sender.Send(query);

        return MatchResult(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTenantRequest request)
    {
        var command = new CreateTenantCommand(request.Name, request.DocumentNumber);
        
        var result = await sender.Send(command);

        return MatchResult(result);
    }
    
    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateTenantRequest request)
    {
        var command = new UpdateTenantCommand(
            id, request.Name, request.DocumentNumber, request.Status);
        
        var result = await sender.Send(command);

        return MatchResult(result);
    }
    
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteTenantCommand(id);
        
        var result = await sender.Send(command);

        return MatchResult(result);
    }

    private IActionResult MatchResult<TReturn>(Result<TReturn, Error> result)
    {
        return result.Match<IActionResult>(
            success => StatusCode(StatusCodes.Status200OK, result.Data),
            failure => failure.Code switch
            {
                TenantErrors.NotFoundErrorCode => StatusCode(StatusCodes.Status404NotFound, failure),
                TenantErrors.DocumentNumberNotUniqueErrorCode => StatusCode(StatusCodes.Status409Conflict, failure),
                _ => StatusCode(StatusCodes.Status400BadRequest, failure),
            });
    }
}