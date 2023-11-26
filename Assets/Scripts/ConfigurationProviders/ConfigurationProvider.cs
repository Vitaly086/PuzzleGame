using UnityEngine;

namespace ConfigurationProviders
{
    /// <summary>
    /// Провайдер со всеми другими провайдерами настроек
    /// </summary>
    [CreateAssetMenu(fileName = "ConfigurationProvider", menuName = "ScriptableObjects/ConfigurationProvider")]
    public class ConfigurationProvider : ScriptableObject, IConfigurationProvider
    {
        public ILevelSettingsProvider LevelSettingsProvider => _levelSettings;

        [SerializeField] private LevelSettingsProvider _levelSettings;

        public void Initialize()
        {
            _levelSettings.Initialize();
        }
    }
}