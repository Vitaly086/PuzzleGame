namespace Screens.StoreScreen
{
    public class StoreScreenContext
    {
        public int Score { get; }
        public int Level { get; }
        public float LevelProgress { get; }

        public StoreScreenContext(int level, float levelProgress, int score)
        {
            Score = score;
            LevelProgress = levelProgress;
            Level = level;
        }
    }
}