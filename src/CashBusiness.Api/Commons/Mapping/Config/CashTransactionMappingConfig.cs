using CashBusiness.Contracts.CashTransaction.Requests;
using CashBusiness.Contracts.CashTransaction.Responses;
using CashBusiness.Domain.Entity;
using FluentResults;
using Mapster;

namespace CashBusiness.Api.Commons.Mapping.Config;

public class CashTransactionMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterCashTransactionRequest, CashTransaction>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.Observation, src => src.Observation)
            .Map(dest => dest.Voucher, src => src.Voucher)
            .Map(dest => dest.OperationId, src => src.OperationId);
        
        config.NewConfig<CashTransaction, CashTransactionResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.Observation, src => src.Observation)
            .Map(dest => dest.OperationId, src => src.OperationId)
            .Map(dest => dest.Voucher, src => src.Voucher)
            .Map(dest => dest.CustomerId, src => src.CustomerId);

        config.NewConfig<UpdateCashTransactionRequest, CashTransaction>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Observation, src => src.Observation)
            .Map(dest => dest.OperationId, src => src.OperationId)
            .Map(dest => dest.Voucher, src => src.Voucher)
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.Amount, source => source.Amount);
        
    }
}