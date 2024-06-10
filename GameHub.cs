using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;

public class GameHub : Hub
{
    private static readonly ConcurrentDictionary<string, int> UserClickCounts = new ConcurrentDictionary<string, int>();

    public async Task Click()
    {
        var connectionId = Context.ConnectionId;
        UserClickCounts.AddOrUpdate(connectionId, 1, (key, oldValue) => oldValue + 1);
        
        await Clients.Caller.SendAsync("UpdateClickCount", UserClickCounts[connectionId]);
    }

    public async Task Reset()
    {
        var connectionId = Context.ConnectionId;
        UserClickCounts[connectionId] = 0;
        await Clients.Caller.SendAsync("UpdateClickCount", 0);
    }
}
