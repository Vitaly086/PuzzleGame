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
            var currentRollsCount = LevelProvider.RollsCount.Value;
            var level = LevelSettingsProvider.GetLevelByRolls(currentRollsCount);
            float rollsForUpgrade = LevelSettingsProvider.GetRollsCount(level);

            // Если есть предыдущий уровень
            var previousLevel = level > 1 ? level - 1 : 0;
            if (previousLevel != 0)
            {
                // находим количество бросков чисто на текущем уровне (за вычетом предыдущих)
                // Для правильного расчета прогресса текущего уровня
                rollsForUpgrade -= LevelSettingsProvider.GetRollsCount(previousLevel);
                currentRollsCount -= LevelSettingsProvider.GetRollsCount(previousLevel);
            }

            var levelProgress = currentRollsCount / rollsForUpgrade;
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