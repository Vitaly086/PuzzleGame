using DefaultNamespace.Events;
using ScreenManager.Core;

public class LeaderboardScreen :  UIScreen<LeaderboardScreenContext>
{
    public override void Initialize(LeaderboardScreenContext context)
    {
        EventStreams.UserInterface.Publish(new OpenLeaderboardEvent());
    }
}