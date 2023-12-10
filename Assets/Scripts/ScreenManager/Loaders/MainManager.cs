using ConfigurationProviders;
using GameStates;
using IngameStateMachine;
using Score;
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
            var scoreService = new ScoreService(userProfile);
            
            CreateAndInitializeStateMachine(userProfile, scoreService);
        }
        
        private void CreateAndInitializeStateMachine(UserProfile userProfile, IScoreService scoreService)
        {
            _stateMachine = new StateMachine
            (
                new MetaGameState(userProfile, userProfile, _configurationProvider.LevelSettingsProvider),
                new MenuState(userProfile, userProfile, _configurationProvider.LevelSettingsProvider),
                new StoreState(userProfile, userProfile, _configurationProvider.LevelSettingsProvider, scoreService),
                new LeaderboardState(userProfile, userProfile, _configurationProvider.LevelSettingsProvider),
                new GameState(userProfile, scoreService)
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
        