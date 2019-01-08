using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using GoLive.Core.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace GoLive.API.Features.Customers
{
    public class GoLiveCustomerCommand
    {
        public class Request : IRequest<Unit> {
            public Guid CustomerId { get; set; }
        }

        public class Response
        {
            public int CustomerId { get;set; }
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken) {
                return new Unit();
            }
        }
    }
}
