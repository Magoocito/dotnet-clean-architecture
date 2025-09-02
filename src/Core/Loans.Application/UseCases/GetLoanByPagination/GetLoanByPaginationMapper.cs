using AutoMapper;
using Loans.Application.UseCases.Dtos;
using Loans.Application.UseCases.GetAllLoans;
using Loans.Domain.Entities;
using Loans.Domain.Types;

namespace Loans.Application.UseCases.GetLoanByPagination
{
    public class GetLoanByPaginationMapper : Profile
    {
        public GetLoanByPaginationMapper()
        {
            CreateMap<LoanDomain, LoanItemResponse>()
                .ForMember(dest => dest.OverdueCount, opt => opt.MapFrom(
                    src => src.Installments.Count(i => i.Status == InstallmentStatus.Overdue)));
        }
    }
}
