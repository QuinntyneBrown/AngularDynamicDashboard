using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using AngularDynamicDashboard.Api.Core;
using AngularDynamicDashboard.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AngularDynamicDashboard.Api.Features
{
    public class GetStoredEvents
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<StoredEventDto> StoredEvents { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAngularDynamicDashboardDbContext _context;
        
            public Handler(IAngularDynamicDashboardDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    StoredEvents = await _context.StoredEvents.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
