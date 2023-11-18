using Events;
using ScreenManager.Core;

namespace Screens.LeaderboardScreen
{
    public class LeaderboardScreen :  UIScreen<LeaderboardScreenContext>
    {
        public override void Initialize(LeaderboardScreenContext context)
        {
            EventStreams.UserInterface.Publish(new OpenLeaderboardEvent());
        }
    }
}