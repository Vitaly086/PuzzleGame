using UniRx;

namespace GameServices
{
    public interface IPlayerProgressService
    {
        IReadOnlyReactiveProperty<int> GetCurrentLevel();
        int GetCurrentLevelRollsCount();
        void MarkCurrentLevelAsPassed();
        void UpdateRollsCount(int count);
    }
}