using Events;
using ScreenManager.Core;
using Screens.MenuScreen;
using Screens.MetaGameScreen;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace GameStates
{
    public class MenuState : MetaGameState
    {
        private CompositeDisposable _subscriptions;

        public MenuState(IScoreProvider scoreProvider, ILevelProvider levelProvider,
            ILevelSettingsProvider levelSettingsProvider) : base(scoreProvider,
            levelProvider, levelSettingsProvider)
        {
        }

        public override void OnEnter()
        {
            SubscribeMenuButtons();
            float rollsCount = LevelProvider.RollsCount.Value;
            var level = LevelProvider.Level.Value;
            var levelProgress = rollsCount / LevelSettingsProvider.GetRollsCount(level);
            var score = ScoreProvider.Score.Value;
            
            ScreensManager.OpenScreen<MenuScreen, MenuScreenContext>(
                new MenuScreenContext(level, levelProgress, score));

            _subscriptions = new CompositeDisposable
            {
                EventStreams.UserInterface.Subscribe<PlayButtonPressedEvent>(EnterGameState)
            };
        }

        private void EnterGameState(PlayButtonPressedEvent obj)
        {
            ScreensManager.CloseScreen<MetaGameScreen>();
            StateMachine.Enter<GameState>();
        }

        public override void OnExit()
        {
            base.OnExit();
            _subscriptions?.Dispose();
            ScreensManager.CloseScreen<MenuScreen>();
        }
    }
}