using UniRx;
using User;

namespace GameServices
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreProvider _scoreProvider;
        
        public IReadOnlyReactiveProperty<int> Score => _scoreProvider.Score;
        
        public ScoreService(IScoreProvider scoreProvider)
        {
            _scoreProvider = scoreProvider;
        }
        
        public void Pay(int amount)
        {
            if (HasEnoughScore(amount))
            {
                _scoreProvider.Score.Value -= amount;
            }
        }
    
        public void Receive(int value)
        {
            _scoreProvider.Score.Value += value;
        }

        public bool HasEnoughScore(int amount)
        {
            return _scoreProvider.Score.Value >= amount;
        }
    }
}