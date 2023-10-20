using CashBusiness.Contracts.Transaction.vo;
using CashBusiness.Domain.Entity;
using Mapster;

namespace CashBusiness.Api.Commons.Mapping.Config;

public class OperationMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Operation, OperationVo>()
            .Map(destination => destination.Id, source => source.Id.ToString())
            .Map(destination => destination.Name, source => source.Name );
    }
}