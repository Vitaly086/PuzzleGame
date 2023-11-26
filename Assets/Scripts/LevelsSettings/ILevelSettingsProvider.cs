using UnityEngine;

public interface ILevelSettingsProvider
{
    string GetName(int id);
    bool IsLastLevel(int level);
}