using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace LevelsSettings
{
    /// <summary>
    /// Класс с настройками всех уровней.
    /// </summary>
    [CreateAssetMenu(fileName = "LevelSettingsProvider", menuName = "ScriptableObjects/LevelSettingsProvider")]
    public class LevelSettingsProvider : ScriptableObject, ILevelSettingsProvider
    {
        [SerializeField] private LevelSettings[] _levelSettings;

        private Dictionary<int, LevelSettings> _levelSettingsById;
        private Dictionary<float, LevelSettings> _levelSettingsByRollsCount;

        public void Initialize()
        {
            _levelSettingsById = new();
            _levelSettingsByRollsCount = new ();

            foreach (var levelSettings in _levelSettings)
            {
                var hasId = _levelSettingsById.ContainsKey(levelSettings.Id);
                Assert.IsFalse(hasId, $"Id {levelSettings.Id} has already existed, " +
                                      "please check the levels Id in levelSettingsProvider");

                _levelSettingsById[levelSettings.Id] = levelSettings;
                _levelSettingsByRollsCount[levelSettings.RollsForUpgrade] = levelSettings;
            }
        }
    
        public int GetLevelByRolls(int rolls)
        {
            foreach (var keyValuePair in _levelSettingsByRollsCount)
            {
                if (rolls < keyValuePair.Key)
                {
                    var level = _levelSettingsByRollsCount[keyValuePair.Key];
                    return level.Id;
                }
            }

            // Если количество бросков больше значений всех уровней - возвращаем последний
            return _levelSettings[^1].Id;
        }

        public int GetRollsCount(int id)
        {
            var level = _levelSettingsById[id];
            return level.RollsForUpgrade;
        }

        public bool IsLastLevel(int level)
        {
            return level >= _levelSettings.Length;
        }

        public float GetLevelProgress(int level, int currentRollsCount)
        {
            float rollsForUpgrade = GetRollsCount(level);
        
        
            // Если есть предыдущий уровень
            var previousLevel = level > 1 ? level - 1 : 0;
            if (previousLevel != 0)
            {
                // находим количество бросков чисто на текущем уровне (за вычетом предыдущих)
                // Для правильного расчета прогресса текущего уровня
                rollsForUpgrade -= GetRollsCount(previousLevel);
                currentRollsCount -= GetRollsCount(previousLevel);
            }

            return currentRollsCount / rollsForUpgrade;
        }
    }
}