using LevelsSettings;

namespace ConfigurationProviders
{
    public interface IConfigurationProvider
    {
        public ILevelSettingsProvider LevelSettingsProvider { get; }
        
        void Initialize();
    }
}