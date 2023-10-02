using AutoMapper;
using Transaction.WebApi.Dto.Account;
using Transaction.WebApi.Models.Account;

namespace Transaction.WebApi.MappingProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountSummary, ViewBalanceDto>()
            .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.AccountNumber))
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
            .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance));
        }    
    }
}
