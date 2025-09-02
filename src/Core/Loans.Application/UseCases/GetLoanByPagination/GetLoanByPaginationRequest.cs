using Loans.Application.UseCases.Dtos;
using Loans.Application.UseCases.GetAllLoans;
using MediatR;

namespace Loans.Application.UseCases.GetLoanByPagination
{
    public class GetLoanByPaginationRequest : IRequest<PagedList<LoanItemResponse>>
    {
        public PaginationParameters Parameters { get; }

        public GetLoanByPaginationRequest(PaginationParameters parameters)
        {
            Parameters = parameters;
        }
    }
}
