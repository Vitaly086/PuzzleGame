using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Класс с настройками всех уровней.
/// </summary>
[CreateAssetMenu(fileName = "LevelSettingsProvider", menuName = "LevelSettingsProvider")]
public class LevelSettingsProvider : ScriptableObject, ILevelSettingsProvider
{
    [SerializeField] 
    private LevelSettings[] _levelSettings;
    
    private Dictionary<string, LevelSettings> _levelSettingsByName;
    private Dictionary<int, LevelSettings> _levelSettingsById;
        
    public void Initialize()
    {
        _levelSettingsByName = new ();
        _levelSettingsById = new ();
        
        foreach (var levelSettings in _levelSettings)
        {
            var hasId = _levelSettingsById.ContainsKey(levelSettings.Id);
            Assert.IsFalse(hasId, $"Id {levelSettings.Id} has already existed, " +
                                  "please check the levels Id in levelSettingsProvider");
                
            _levelSettingsById[levelSettings.Id] = levelSettings;
            _levelSettingsByName[levelSettings.Name] = levelSettings;
        }
    }

    public string GetName(int id)
    {
        var level = _levelSettingsById[id];
        return level.Name;
    }
        
    public bool IsLastLevel(int level)
    {
        return level >= _levelSettings.Length;
    }
}