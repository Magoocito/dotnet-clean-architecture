using Loans.Application.UseCases.CreateLoan;
using Loans.Application.UseCases.GetAllLoans;
using Loans.Application.UseCases.GetInstallmentsByLoandId;
using Loans.Application.UseCases.GetLoanByPagination;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Loans.Application.Services
{
    public static class ServiceExtesions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(
                typeof(CreateLoanMapper).Assembly,
                typeof(GetAllLoansMapper).Assembly,
                typeof(GetInstallmentsByLoanIdMapper).Assembly,
                typeof(GetLoanByPaginationMapper).Assembly
                );

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
