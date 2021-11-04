using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AngularDynamicDashboard.Api.Core;
using AngularDynamicDashboard.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AngularDynamicDashboard.Api.Features
{
    public class GetDashboardCardById
    {
        public class Request: IRequest<Response>
        {
            public Guid DashboardCardId { get; set; }
        }

        public class Response: ResponseBase
        {
            public DashboardCardDto DashboardCard { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAngularDynamicDashboardDbContext _context;
        
            public Handler(IAngularDynamicDashboardDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    DashboardCard = (await _context.DashboardCards.SingleOrDefaultAsync(x => x.DashboardCardId == request.DashboardCardId)).ToDto()
                };
            }
            
        }
    }
}
