using System;
using ConfigurationProviders;
using UniRx;

namespace UserProgress
{
    /// <summary>
    /// Следит за прогрессом пользователя и сохраняет его через методы PrefsManager
    /// </summary>
    public class ProfileStorage : IDisposable
    {
        private readonly IConfigurationProvider _configurationProvider;
        private CompositeDisposable _subscriptions;
        
        public ProfileStorage(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public UserProfile GetLastUserProfile()
        {
            var userScore = PrefsManager.LoadScore();
            var rollsCount = PrefsManager.LoadRollsCount();
            var level = _configurationProvider.LevelSettingsProvider.GetLevelByRolls(rollsCount);

            var userProfile = new UserProfile(userScore, level, rollsCount);
            return userProfile;
        }

        public void StartTrackingChanges(UserProfile userProfile)
        {
            _subscriptions?.Dispose();

            _subscriptions = new CompositeDisposable();

            var moneySubscription = userProfile.Score
                .Subscribe(PrefsManager.SaveScoreProgress);
            _subscriptions.Add(moneySubscription);

            var playerProgressSubscription = userProfile.RollsCount
                .Subscribe(PrefsManager.SaveRollsCount);
            _subscriptions.Add(playerProgressSubscription);
        }

        public bool HasProgress()
        {
            return PrefsManager.HasUserProfile();
        }

        public void Dispose()
        {
            _subscriptions?.Dispose();
        }
    }
}