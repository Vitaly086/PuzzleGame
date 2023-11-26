using UniRx;

public interface IScoreProvider
{
    ReactiveProperty<int> Score { get; }
}