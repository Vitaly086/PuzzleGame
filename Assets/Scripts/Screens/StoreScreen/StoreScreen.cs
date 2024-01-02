using System.Collections.Generic;
using Events;
using GameCore.Dice;
using GameCore.DiceDatas;
using GameCore.Settings;
using GameServices;
using JetBrains.Annotations;
using Score;
using ScreenManager.Core;
using Screens.MenuScreen;
using UniRx;
using UnityEngine;
using Upgrades;
using Zenject;

namespace Screens.StoreScreen
{
    public class StoreScreen : UIScreen<StoreScreenContext>
    {
        [SerializeField]
        private GameObject _backButton;
        [SerializeField]
        private ScoreView _scoreView;
        [SerializeField]
        private LevelProgressView _levelProgressView;
        [SerializeField]
        private DiceHandPresenter _diceHandPresenter;
        [SerializeField]
        private DiceFacesPresenter _diceFacesPresenter;
        [SerializeField]
        private SpellsPresenter _spellsPresenter;

        [SerializeField]
        private GameObject DicesScreen;
        [SerializeField]
        private GameObject FacesScreen;
        [SerializeField]
        private GameObject SpellsScreen;

        private HandWithDices _handWithDices;

        private IScoreService _scoreService;
        private GameObject _currentScreen;
        private readonly Stack<GameObject> _openedScreensStack = new();
        private DiceDataManager _diceDataManager;

        [Inject]
        private void Construct(HandWithDices handWithDices, DiceDataManager diceDataManager)
        {
            _diceDataManager = diceDataManager;
            _handWithDices = handWithDices;
        }

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

            _diceHandPresenter.DiceButtonCreated += SubscribeDiceButtonClick;
            _diceFacesPresenter.FaceButtonClicked += OpenSpellsScreen;

            _diceHandPresenter.Initialize(_handWithDices, _diceDataManager);
        }

        [UsedImplicitly]
        public void OpenPreviousScreen()
        {
            // Достаем предыдущий экран
            var previousScreen = _openedScreensStack.Pop();
            ChangeStoreScreen(previousScreen);
        }

        private void UpdateScoreView(int newScore)
        {
            _scoreView.UpdateView(_scoreService.Score.Value);
        }

        private void SubscribeDiceButtonClick(DiceButtonPresenter diceButton)
        {
            var button = diceButton.Button;
            var facesSettings = diceButton.DiceFacesConfig;
            button.onClick.AddListener(() => OpenFacesScreen(facesSettings));
        }

        private void OpenFacesScreen(DiceFacesConfig diceFacesConfig)
        {
            // Кладем в стек предыдущий открытый экран
            _openedScreensStack.Push(_currentScreen);
            _diceFacesPresenter.Initialize(diceFacesConfig); //Вызывается перед ChangeStoreScreen()
            ChangeStoreScreen(FacesScreen); 
        }

        private void OpenSpellsScreen(DiceFacesConfig diceFacesConfig, int faceIndex)
        {
            // Кладем в стек предыдущий открытый экран
            _openedScreensStack.Push(_currentScreen);

            ChangeStoreScreen(SpellsScreen);

            var faceUpgradeService = new FaceUpgradeService(diceFacesConfig, _scoreService);
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