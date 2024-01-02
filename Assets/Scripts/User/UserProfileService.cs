using ConfigurationProviders;
using UserProgress;

namespace User
{
    /// <summary>
    /// Создает профиль игрока
    /// </summary>
    public class UserProfileService : IUserProfileService
    {
        private readonly ProfileStorage _profileStorage;
        
        public UserProfileService(IConfigurationProvider configurationProvider)
        {
            _profileStorage = new ProfileStorage(configurationProvider);
        }
        
        public UserProfile GetProfile()
        {
            UserProfile userProfile;
            
            if (_profileStorage.HasProgress())
            {
                userProfile = _profileStorage.GetLastUserProfile();
            }
            else
            {
                userProfile = new UserProfile();
            }
            
            _profileStorage.StartTrackingChanges(userProfile);
            return userProfile;
        }

        public void Dispose()
        {
            _profileStorage.Dispose();
        }
    }
}