using System;
using Events;
using UniRx;

namespace Score
{
    public class ScoreController : IDisposable
    {
        private int _value;
        private readonly ScoreView _scoreView;
        private readonly CompositeDisposable _disposable;

        private ScoreController(ScoreView scoreView)
        {
            _disposable = new CompositeDisposable()
            {
                EventStreams.UserInterface.Subscribe<DiceRollCompletedEvent>(DiceRollCompleted)
            };

            _scoreView = scoreView;
        }

        private void DiceRollCompleted(DiceRollCompletedEvent eventData)
        {
            var score = eventData.Value;
            SetScore(score);
        }

        private void SetScore(int value)
        {
            var currentScore = _value;
            _value += value;
            _scoreView.UpdateViewGradually(currentScore, _value);
        }

        public bool TryBuy(int price)
        {
            if (_value >= price)
            {
                _value -= price;
                _scoreView.UpdateView(_value, _value);
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}