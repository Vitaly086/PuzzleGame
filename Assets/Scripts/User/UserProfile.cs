using UniRx;

namespace User
{
    public class UserProfile : ILevelProvider, IScoreProvider
    {
        private const int INITIAL_LEVEL_ID = 1;
    
        public ReactiveProperty<int> Score { get; }
        public ReactiveProperty<int> RollsCount { get; }
        public ReactiveProperty<int> Level { get; }

        public UserProfile(int score, int level, int rollsCount)
        {
            Score = new ReactiveProperty<int>(score);
            Level = new ReactiveProperty<int>(level);
            RollsCount = new ReactiveProperty<int>(rollsCount);
        }

        public UserProfile()
        {
            Score = new ReactiveProperty<int>(0);
            Level = new ReactiveProperty<int>(INITIAL_LEVEL_ID);
            RollsCount = new ReactiveProperty<int>(0);
        }
    }
}