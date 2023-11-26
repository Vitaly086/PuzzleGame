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
            var userMoney = PrefsManager.LoadScore();
            var userProgress = PrefsManager.LoadPlayerProgress();

            var userProfile = new UserProfile(userMoney, userProgress);
            return userProfile;
        }

        public void StartTrackingChanges(UserProfile userProfile)
        {
            _subscriptions?.Dispose();

            _subscriptions = new CompositeDisposable();

            var moneySubscription = userProfile.Score
                .Subscribe(PrefsManager.SaveScoreProgress);
            _subscriptions.Add(moneySubscription);

            var playerProgressSubscription = userProfile.Level
                .Subscribe(PrefsManager.SavePlayerProgress);
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