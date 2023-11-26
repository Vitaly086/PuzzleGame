using Events;
using JetBrains.Annotations;
using Score;
using ScreenManager.Core;
using UniRx;
using UnityEngine;

namespace Screens.GameScreen
{
    public class GameScreen : UIScreen<GameScreenContext>
    {
        [SerializeField] private ScoreView _scoreView;
        
        private IScoreService _scoreService;
        private int _currentScore;
        private bool _isStartGame = true;

        public override void Initialize(GameScreenContext context)
        {
            _scoreService = context.ScoreService;
            _scoreService.Score.Subscribe(UpdateScoreView).AddTo(this);
        }

        private void UpdateScoreView(int newScore)
        {
            if (_isStartGame)
            {
                _scoreView.UpdateView(_scoreService.Score.Value);
                _isStartGame = false;
            }
            else
            {
                _scoreView.UpdateViewGradually(_currentScore, newScore);
                _currentScore = newScore;
            }
        }

        [UsedImplicitly]
        public void PressMenuButton()
        {
            EventStreams.UserInterface.Publish(new MenuButtonPressedEvent());
        }
    }
}