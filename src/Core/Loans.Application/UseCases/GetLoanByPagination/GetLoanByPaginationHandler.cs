using AutoMapper;
using Loans.Application.Repositories;
using Loans.Application.UseCases.Dtos;
using Loans.Application.UseCases.GetAllLoans;
using MediatR;

namespace Loans.Application.UseCases.GetLoanByPagination
{
    public class GetLoanByPaginationHandler : IRequestHandler<GetLoanByPaginationRequest, PagedList<LoanItemResponse>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public GetLoanByPaginationHandler(ILoanRepository loanRepository,
            IMapper mapper)
        {
            this._loanRepository = loanRepository;
            this._mapper = mapper;
        }

        public async Task<PagedList<LoanItemResponse>> Handle(GetLoanByPaginationRequest request, CancellationToken cancellationToken)
        {
            var (loans, totalCount) = await _loanRepository.GetPagedLoansAsync(request.Parameters, cancellationToken);
            var items = _mapper.Map<List<LoanItemResponse>>(loans);
            int totalPages = (int)Math.Ceiling(totalCount / (double)request.Parameters.PageSize);
            int pageNumber = request.Parameters.PageNumber > totalPages ? totalPages : request.Parameters.PageNumber;
            pageNumber = pageNumber == 0 ? 1 : pageNumber;

            var responsePageList = new PagedList<LoanItemResponse>
                (
                    items,
                    pageNumber,
                    totalPages,
                    totalCount
                );

            return responsePageList;
        }
    }
}
