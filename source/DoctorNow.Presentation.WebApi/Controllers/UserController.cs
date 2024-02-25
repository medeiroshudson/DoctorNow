using DoctorNow.Application.Features.Users.Commands.Authenticate;
using DoctorNow.Application.Features.Users.Commands.Create;
using DoctorNow.Application.Features.Users.Contracts;
using DoctorNow.Application.Features.Users.Queries.GetAll;
using DoctorNow.Application.Features.Users.Queries.GetById;
using DoctorNow.Presentation.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorNow.Presentation.WebApi.Controllers;

[ApiController, Route("[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [Authorize, HttpGet]
    public async Task<IActionResult > Get()
    {
        var result = await mediator.Send(
            new GetAllUsersQuery());

        return result.IsFailure
            ? result.ConvertToFailureActionResult()
            : StatusCode(StatusCodes.Status200OK, result.Data);
    }
    
    [Authorize, HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(
            new GetUserByIdQuery(id));

        return result.IsFailure
            ? result.ConvertToFailureActionResult()
            : StatusCode(StatusCodes.Status200OK, result.Data);
    }
    
    [Authorize, HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
    {
        var command = new CreateUserCommand(
            request.TenantId, request.Name, request.Email, request.Password);
        
        var result = await mediator.Send(command);

        return result.IsFailure
            ? result.ConvertToFailureActionResult()
            : StatusCode(StatusCodes.Status201Created, result.Data);
    }
    
    [HttpPost("token")]
    public async Task<IActionResult> Token([FromBody] AuthenticateUserRequest request)
    {
        var command = new AuthenticateUserCommand(request.Email, request.Password);
        
        var result = await mediator.Send(command);

        return result.IsFailure
            ? result.ConvertToFailureActionResult()
            : StatusCode(StatusCodes.Status200OK, result.Data);
    }
}