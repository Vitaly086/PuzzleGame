namespace Screens.MenuScreen
{
    public class MenuScreenContext
    {
        public float LevelProgress { get; set; }

        public MenuScreenContext(float levelProgress)
        {
            LevelProgress = levelProgress;
        }
    }
}