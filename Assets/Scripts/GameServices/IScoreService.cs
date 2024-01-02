using UniRx;

namespace GameServices
{
    public interface IScoreService
    {
        IReadOnlyReactiveProperty<int> Score { get; }
        void Pay(int amount);
        void Receive(int score);
        bool HasEnoughScore(int amount);
    }
}