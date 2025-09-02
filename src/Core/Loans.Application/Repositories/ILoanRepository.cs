using Loans.Application.UseCases.Dtos;
using Loans.Domain.Entities;

namespace Loans.Application.Repositories
{
    public interface ILoanRepository
    {
        public Task<List<LoanDomain>> GetAllAsync(CancellationToken cancellationToken);
        public Task<LoanDomain> GetByIdAsync(int loanId, CancellationToken cancellationToken);
        Task CreateAsync(LoanDomain domain, CancellationToken cancellationToken);
        Task UpdateAsyn(LoanDomain domain, CancellationToken cancellationToken);
        Task<(List<LoanDomain> Loans, int TotalCount)> GetPagedLoansAsync(PaginationParameters parameters, CancellationToken cancellationToken);
    }
}
