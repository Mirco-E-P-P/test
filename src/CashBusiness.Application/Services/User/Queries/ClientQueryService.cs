using CashBusiness.Application.Common.Errors.User;
using CashBusiness.Application.Common.Persistence.user;
using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.User.Queries;

public class ClientQueryService: IClientQueryService
{
    private readonly IClientRepository _clientRepository;

    public ClientQueryService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<Result<Client>> FindClientById(string id)
    {
        Client client = await _clientRepository.FindClientById(id);

        if (client == null)
        {
            return Result.Fail(new NotFoundClient($"No such client found for id: {id}" ));
        }
        return Result.Ok(client);
    }

    public async Task<Result<List<Client>>> FindAllClients()
    {
        throw new NotImplementedException("not implemented method");
    }
    
}