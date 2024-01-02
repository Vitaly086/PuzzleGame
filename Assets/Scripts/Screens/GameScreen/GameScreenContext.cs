using GameServices;

namespace Screens.GameScreen
{
    public class GameScreenContext
    {
        public IScoreService ScoreService { get; }

        public GameScreenContext(IScoreService scoreService)
        {
            ScoreService = scoreService;
        }
    }
}