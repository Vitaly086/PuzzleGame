using ConfigurationProviders;
using GameStates;
using IngameStateMachine;
using UnityEngine;

namespace ScreenManager.Loaders
{
    public class MainManager : MonoBehaviour
    {
        [SerializeField] 
        private ConfigurationProvider _configurationProvider;
        private StateMachine _stateMachine;

        private void Awake()
        {
            _configurationProvider.Initialize();
            var userProfile = GetUserProfile(_configurationProvider);
            CreateAndInitializeStateMachine(userProfile);
        }
        
        private void CreateAndInitializeStateMachine(UserProfile userProfile)
        {
            _stateMachine = new StateMachine
            (
                new MetaGameState(userProfile, _configurationProvider.LevelSettingsProvider),
                new MenuState(userProfile, _configurationProvider.LevelSettingsProvider),
                new StoreState(userProfile, _configurationProvider.LevelSettingsProvider),
                new LeaderboardState(userProfile, _configurationProvider.LevelSettingsProvider),
                new GameState(userProfile)
            );

            _stateMachine.Initialize();
            _stateMachine.Enter<MetaGameState>();
        }

        private UserProfile GetUserProfile(ConfigurationProvider configurationProvider)
        {
            var userProfileService = new UserProfileService(configurationProvider);
            return userProfileService.GetProfile();
        }
    }
}
        