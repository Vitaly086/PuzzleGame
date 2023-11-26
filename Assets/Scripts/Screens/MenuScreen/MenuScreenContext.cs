namespace Screens.MenuScreen
{
    public class MenuScreenContext
    {
        public int Level { get; set; }
        public float LevelProgress { get; set; }
        public int Score { get; set; }

        public MenuScreenContext(int level, float levelProgress, int score)
        {
            Level = level;
            LevelProgress = levelProgress;
            Score = score;
        }
    }
}