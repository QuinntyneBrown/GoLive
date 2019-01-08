using GoLive.Core.Model;
using GoLive.Core.Model;
using System;

namespace GoLive.API.Features.Customers
{
    public class CustomerDto
    {        
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public bool IsLive { get; set; }
        public static CustomerDto FromCustomer(Customer customer)
            => new CustomerDto
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                IsLive = customer.IsLive
            };
    }
}
