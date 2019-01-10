using System;
using System.Collections.Generic;
using System.Text;

namespace GoLive.Core.Identity
{
    public interface ISecurityTokenFactory
    {
        string Create(Guid userId, string uniqueName);
    }
}
