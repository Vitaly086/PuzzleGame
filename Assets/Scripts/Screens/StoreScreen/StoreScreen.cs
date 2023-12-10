using System;
using System.Collections.Generic;
using Events;
using GameCore.Dice;
using JetBrains.Annotations;
using Score;
using ScreenManager.Core;
using Screens.MenuScreen;
using UniRx;
using UnityEngine;

namespace Screens.StoreScreen
{
    public class StoreScreen : UIScreen<StoreScreenContext>
    {
        [SerializeField] private GameObject _backButton;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private LevelProgressView _levelProgressView;
        [SerializeField] private DiceHandPresenter _diceHandPresenter;
        [SerializeField] private DiceFacesPresenter _diceFacesPresenter;
        [SerializeField] private SpellsPresenter _spellsPresenter;

        [SerializeField] private GameObject DicesScreen;
        [SerializeField] private GameObject FacesScreen;
        [SerializeField] private GameObject SpellsScreen;

        [SerializeField] private HandWithDices _handWithDices; // Пока захардкожено!!!

        private IScoreService _scoreService;
        private GameObject _currentScreen;
        private Stack<GameObject> _openedScreensStack = new();

        public override void Initialize(StoreScreenContext context)
        {
            _openedScreensStack.Clear();
            _currentScreen = DicesScreen;
            
            EventStreams.UserInterface.Publish(new OpenStoreEvent());

            _levelProgressView.SetLevelValue(context.Level);
            _levelProgressView.SetSprite(context.LevelProgress);
            _scoreView.UpdateView(context.Score);
            _scoreService = context.ScoreService;

            _scoreService.Score.Subscribe(UpdateScoreView).AddTo(this);

            _diceFacesPresenter.FaceButtonClicked += OpenSpellsScreen;
            _diceHandPresenter.DiceButtonCreated += SubscribeDiceButtonClick;
            
            _diceHandPresenter.Initialize(_handWithDices);
        }

        [UsedImplicitly]
        public void OpenPreviousScreen()
        {
            // Достаем предыдущий экран
            var previousScreen = _openedScreensStack.Pop();
            ChangeStoreScreen(previousScreen);
            
            Debug.LogError(_openedScreensStack.Count);
        }

        private void UpdateScoreView(int newScore)
        {
            _scoreView.UpdateView(_scoreService.Score.Value);
        }

        private void SubscribeDiceButtonClick(DiceButtonPresenter diceButton)
        {
            var button = diceButton.Button;
            var facesSettings = diceButton.DiceFacesSettings;
            button.onClick.AddListener(() => OpenFacesScreen(facesSettings));
        }

        private void OpenFacesScreen(DiceFacesSettings diceFacesSettings)
        {
            // Кладем в стек предыдущий открытый экран
            _openedScreensStack.Push(_currentScreen);
            ChangeStoreScreen(FacesScreen);

            _diceFacesPresenter.Initialize(diceFacesSettings);
        }

        private void OpenSpellsScreen(DiceFacesSettings diceFacesSettings, int faceIndex)
        {
            // Кладем в стек предыдущий открытый экран
            _openedScreensStack.Push(_currentScreen);
            Debug.LogError("Add " + _currentScreen);
            
            ChangeStoreScreen(SpellsScreen);

            var faceUpgradeService = new FaceUpgradeService(diceFacesSettings, _scoreService);
            _spellsPresenter.Initialize(faceUpgradeService, _scoreService, faceIndex);
        }

        private void ChangeStoreScreen(GameObject nextScreen)
        {
            _currentScreen.SetActive(false);
            _currentScreen = nextScreen;
            _currentScreen.SetActive(true);
            _backButton.SetActive(_currentScreen != DicesScreen);
        }

        private void OnDisable()
        {
            _diceFacesPresenter.FaceButtonClicked -= OpenSpellsScreen;
            _diceHandPresenter.DiceButtonCreated -= SubscribeDiceButtonClick;
        }
    }
}