using UniRx;

public class UserProfile : ILevelProvider
{
    public ReactiveProperty<int> Score { get; }
    public ReactiveProperty<int> Level { get; }
    public ReactiveProperty<float> LevelProgress { get; }

    public UserProfile(int score, int userProgress)
    {
        Score = new ReactiveProperty<int>(score);
        Level = new ReactiveProperty<int>(userProgress);
        LevelProgress = new ReactiveProperty<float>(0);
    }

    public UserProfile()
    {
        Score = new ReactiveProperty<int>(0);
        Level = new ReactiveProperty<int>(0);
        LevelProgress = new ReactiveProperty<float>(0);
    }
}