using UnityEngine;

public interface ILevelSettingsProvider
{
    int GetLevelByRolls(int rolls);
    int GetRollsCount(int id);
    bool IsLastLevel(int level);
}