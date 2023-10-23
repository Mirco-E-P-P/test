using CashBusiness.Contracts.Transaction.dto;
using CashBusiness.Contracts.Transaction.vo;
using CashBusiness.Domain.Entity;
using Mapster;

namespace CashBusiness.Api.Commons.Mapping.Config;

public class CashTransactionMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterCashTransactionDto, CashTransaction>()
            .Map(dest => dest.ClientId, src => src.CustomerId)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.Observation, src => src.Observation)
            .Map(dest => dest.Voucher, src => src.Voucher)
            .Map(dest => dest.OperationId, src => src.OperationId);
        
    }
}