using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;


namespace GoLive.API
{
    [Authorize]
    public class AppHub: Hub { }
}
