using UniRx;

namespace GameServices
{
    public interface IPlayerProgressService
    {
        IReadOnlyReactiveProperty<int> GetCurrentLevel();
        float GetCurrentLevelProgress();
        void MarkCurrentLevelAsPassed();
        void UpdateLevelProgress(float progress);
    }
}