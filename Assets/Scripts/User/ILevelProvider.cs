using UniRx;

public interface ILevelProvider
{
    ReactiveProperty<int> Level { get; }
    ReactiveProperty<int> RollsCount { get; }
}