using CashBusiness.Application.Common.Errors.User;
using CashBusiness.Application.Common.Persistence.user;
using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.User.Commands;

public class ClientCommandService: IClientCommandService
{
    private readonly IClientRepository _clientRepository;

    public ClientCommandService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }


    public async Task<Result<Client>> RegisterClient(string name, string phoneNumber)
    {
        Client existingClient = await _clientRepository.FindClientByName(name);
        
        if (existingClient!= null)
        {
            return Result.Fail(new DuplicatedUser($"Client with name {name} already exists"));
        }
        
        Client client = await _clientRepository.PersistedClient(name, phoneNumber);
        return Result.Ok(client);
    }
    
}