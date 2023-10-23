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
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.Observation, src => src.Observation)
            .Map(dest => dest.Voucher, src => src.Voucher)
            .Map(dest => dest.OperationId, src => src.OperationId);
        
        config.NewConfig<CashTransaction, CashTransactionVo>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.Observation, src => src.Observation)
            .Map(dest => dest.OperationId, src => src.OperationId)
            .Map(dest => dest.Voucher, src => src.Voucher)
            .Map(dest => dest.ClientId, src => src.CustomerId);
    }
}