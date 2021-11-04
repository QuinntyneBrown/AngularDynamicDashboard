using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AngularDynamicDashboard.Api.Models;
using AngularDynamicDashboard.Api.Core;
using AngularDynamicDashboard.Api.Interfaces;

namespace AngularDynamicDashboard.Api.Features
{
    public class CreateStoredEvent
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.StoredEvent).NotNull();
                RuleFor(request => request.StoredEvent).SetValidator(new StoredEventValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public StoredEventDto StoredEvent { get; set; }
        }

        public class Response: ResponseBase
        {
            public StoredEventDto StoredEvent { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAngularDynamicDashboardDbContext _context;
        
            public Handler(IAngularDynamicDashboardDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var storedEvent = new StoredEvent();
                
                _context.StoredEvents.Add(storedEvent);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    StoredEvent = storedEvent.ToDto()
                };
            }
            
        }
    }
}
