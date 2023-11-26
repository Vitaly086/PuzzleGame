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
        
        public float GetCurrentLevelProgress()
        {
            return _levelsProvider.LevelProgress.Value;
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

        public void UpdateLevelProgress(float progress)
        {
            _levelsProvider.LevelProgress.Value = progress;
        }
        
        private bool IsLastLevel(int level)
        {
            return _levelsSettings.IsLastLevel(level);
        }
    }
}