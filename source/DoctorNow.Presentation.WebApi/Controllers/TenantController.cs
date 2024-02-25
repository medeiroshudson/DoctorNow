using MediatR;
using Microsoft.AspNetCore.Mvc;
using DoctorNow.Presentation.Common.Extensions;
using DoctorNow.Application.Features.Tenants.Queries;
using DoctorNow.Application.Features.Tenants.Commands;
using DoctorNow.Application.Features.Tenants.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace DoctorNow.Presentation.WebApi.Controllers;

[ApiController, Route("[controller]")]
public class TenantController(IMediator mediator) : ControllerBase
{
    [Authorize, HttpGet]
    public async Task<IActionResult > Get()
    {
        var result = await mediator.Send(
            new GetAllTenantsQuery());

        return result.IsFailure
            ? result.ConvertToFailureActionResult()
            : StatusCode(StatusCodes.Status200OK, result.Data);
    }
    
    [Authorize, HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(
            new GetTenantByIdQuery(id));

        return result.IsFailure
            ? result.ConvertToFailureActionResult()
            : StatusCode(StatusCodes.Status200OK, result.Data);
    }
    
    [Authorize, HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTenantRequest request)
    {
        var command = new CreateTenantCommand(
            request.Name, request.DocumentNumber);
        
        var result = await mediator.Send(command);

        return result.IsFailure
            ? result.ConvertToFailureActionResult()
            : StatusCode(StatusCodes.Status201Created, result.Data);
    }
    
    [Authorize, HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTenantRequest request)
    {
        var command = new UpdateTenantCommand(
            id, request.Name, request.DocumentNumber, request.Status);
        
        var result = await mediator.Send(command);

        return result.IsFailure
            ? result.ConvertToFailureActionResult()
            : StatusCode(StatusCodes.Status200OK, result.Data);
    }
    
    [Authorize, HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(
            new DeleteTenantCommand(id));

        return result.IsFailure
            ? result.ConvertToFailureActionResult()
            : StatusCode(StatusCodes.Status204NoContent);
    }
}