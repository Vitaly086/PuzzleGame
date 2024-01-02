namespace LevelsSettings
{
    public interface ILevelSettingsProvider
    {
        int GetLevelByRolls(int rolls);
        int GetRollsCount(int id);
        bool IsLastLevel(int level);
        float GetLevelProgress(int level, int currentRollsCount);
    }
}