using UniRx;

namespace User
{
    public interface IScoreProvider
    {
        ReactiveProperty<int> Score { get; }
    }
}