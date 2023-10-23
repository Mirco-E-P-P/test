using CashBusiness.Application.Services.User.Commands;
using CashBusiness.Application.Services.User.Queries;
using CashBusiness.Domain.Entity;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace CashBusiness.Api.Controllers.User;

[ApiController]
[Route("client")]
public class ClientController: ControllerBase
{
    private readonly IClientCommandService _clientCommandService;
    private readonly IClientQueryService _clientQueryService;

    public ClientController(IClientQueryService clientQueryService, IClientCommandService clientCommandService)
    {
        _clientQueryService = clientQueryService;
        _clientCommandService = clientCommandService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetClientById(string id)
    {
        Result<Client> clientResult = await _clientQueryService.FindClientById(id);
        
        if (clientResult.IsFailed)
        {
            IError firstError = clientResult.Errors[0];

            return Problem(title: firstError.Message, statusCode: (int) firstError.Metadata["statusCode"]);
        }
        
        return Ok(clientResult.Value);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterClient()
    {
        return Ok();
    }




}