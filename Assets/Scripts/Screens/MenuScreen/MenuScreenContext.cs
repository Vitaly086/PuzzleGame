namespace Screens.MenuScreen
{
    public class MenuScreenContext
    {
        public int Level { get; }
        public float LevelProgress { get; }
        public int Score { get; }

        public MenuScreenContext(int level, float levelProgress, int score)
        {
            Level = level;
            LevelProgress = levelProgress;
            Score = score;
        }
    }
}