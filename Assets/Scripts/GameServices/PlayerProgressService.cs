using UniRx;
using UnityEngine;

namespace GameServices
{
    /// <summary>
    /// Класс, через который апгрейдятся уровни
    /// </summary>
    public class PlayerProgressService : IPlayerProgressService
    {
        private readonly ILevelSettingsProvider _levelsSettings;
        private readonly ILevelProvider _levelsProvider;
        
        public PlayerProgressService(ILevelSettingsProvider levelsSettingsProvider, 
            ILevelProvider levelProvider)
        {
            _levelsSettings = levelsSettingsProvider;
            _levelsProvider = levelProvider;
        }

        public IReadOnlyReactiveProperty<int> GetCurrentLevel()
        {
            return _levelsProvider.Level;
        }
        
        public int GetCurrentLevelRollsCount()
        {
            return _levelsProvider.RollsCount.Value;
        }
        
        public void MarkCurrentLevelAsPassed()
        {
            var level = _levelsProvider.Level;
            
            if (IsLastLevel(level.Value))
            {
                Debug.LogError($"The level with id {level.Value} is last level");
                return;
            }

            level.Value++;
        }
        
        public void UpdateRollsCount(int rollsCount)
        {
            _levelsProvider.RollsCount.Value = rollsCount;
        }
        
        private bool IsLastLevel(int level)
        {
            return _levelsSettings.IsLastLevel(level);
        }
    }
}