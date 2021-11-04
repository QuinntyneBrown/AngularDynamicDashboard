using AngularDynamicDashboard.Api.Core;
using AngularDynamicDashboard.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AngularDynamicDashboard.Api.Features
{
    public class RemoveStoredEvent
    {
        public class Request : IRequest<Response>
        {
            public Guid StoredEventId { get; set; }
        }

        public class Response : ResponseBase
        {
            public StoredEventDto StoredEvent { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAngularDynamicDashboardDbContext _context;

            public Handler(IAngularDynamicDashboardDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var storedEvent = await _context.StoredEvents.SingleAsync(x => x.StoredEventId == request.StoredEventId);

                _context.StoredEvents.Remove(storedEvent);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    StoredEvent = storedEvent.ToDto()
                };
            }

        }
    }
}
