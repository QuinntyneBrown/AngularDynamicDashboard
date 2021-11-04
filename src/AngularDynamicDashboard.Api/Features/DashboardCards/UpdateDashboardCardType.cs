using AngularDynamicDashboard.Api.Core;
using AngularDynamicDashboard.Api.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AngularDynamicDashboard.Api.Features
{
    public class UpdateDashboardCardType
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.DashboardCard).NotNull();
                RuleFor(request => request.DashboardCard).SetValidator(new DashboardCardValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public DashboardCardDto DashboardCard { get; set; }
        }

        public class Response : ResponseBase
        {
            public DashboardCardDto DashboardCard { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAngularDynamicDashboardDbContext _context;

            public Handler(IAngularDynamicDashboardDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var dashboardCard = await _context.DashboardCards.SingleAsync(x => x.DashboardCardId == request.DashboardCard.DashboardCardId);

                dashboardCard.Apply(new DomainEvents.UpdateDashboardCardType(request.DashboardCard.CardType));

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    DashboardCard = dashboardCard.ToDto()
                };
            }

        }
    }
}
