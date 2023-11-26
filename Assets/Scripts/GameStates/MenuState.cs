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

        public MenuState(ILevelProvider levelProvider, ILevelSettingsProvider levelSettingsProvider) : base(
            levelProvider, levelSettingsProvider)
        {
        }

        public override void OnEnter()
        {
            SubscribeMenuButtons();
            var rollsCount = LevelProvider.RollsCount.Value;
            var level = LevelProvider.Level.Value;
            var levelProgress = rollsCount / LevelSettingsProvider.GetRollsCount(level);
            ScreensManager.OpenScreen<MenuScreen, MenuScreenContext>(
                                    new MenuScreenContext(levelProgress));

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