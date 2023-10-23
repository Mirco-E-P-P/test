using CashBusiness.Contracts.User.vo;
using CashBusiness.Domain.Entity;
using Mapster;

namespace CashBusiness.Api.Commons.Mapping.Config;

public class CustomerMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Customer, CustomerVo>()
            .Map(destination => destination.Id, source => source.Id.ToString())
            .Map(destination => destination.Name, source => source.Name)
            .Map(destination => destination.PhoneNumber, source => source.PhoneNumber);
        
    }
}