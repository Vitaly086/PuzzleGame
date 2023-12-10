using Score;

namespace Screens.StoreScreen
{
    public class StoreScreenContext
    {
        public int Score { get; }
        public int Level { get; }
        public float LevelProgress { get; }
        public IScoreService ScoreService { get; }

        public StoreScreenContext(int level, float levelProgress, int score, IScoreService scoreService)
        {
            Score = score;
            LevelProgress = levelProgress;
            Level = level;
            ScoreService = scoreService;
        }
    }
}