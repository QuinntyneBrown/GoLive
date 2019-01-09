using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoLive.API.Features.Customers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController
    {
        private readonly IMediator _meditator;

        public CustomersController(IMediator mediator) => _meditator = mediator;

        [HttpGet]
        public async Task<ActionResult<GetCustomersQuery.Response>> Get()
            => await _meditator.Send(new GetCustomersQuery.Request());

        [HttpGet("customerId")]
        public async Task<ActionResult<GetCustomerByIdQuery.Response>> GetById(GetCustomerByIdQuery.Request request)
            => await _meditator.Send(request);

        [HttpPost]
        public async Task<ActionResult<UpsertCustomerCommand.Response>> Upsert(UpsertCustomerCommand.Request request)
            => await _meditator.Send(request);
    }
}
