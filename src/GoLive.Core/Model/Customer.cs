using System;

namespace GoLive.Core.Model
{
    public class Customer 
    {
        public Guid CustomerId { get; set; }
        public bool IsLive { get; set; }
        public string Name { get; set; }
    }    
}
