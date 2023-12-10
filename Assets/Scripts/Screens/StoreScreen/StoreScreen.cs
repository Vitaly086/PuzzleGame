using Events;
using GameCore.Dice;
using Score;
using ScreenManager.Core;
using Screens.MenuScreen;
using UnityEngine;

namespace Screens.StoreScreen
{
    public class StoreScreen :  UIScreen<StoreScreenContext>
    {
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
        
        
        public override void Initialize(StoreScreenContext context)
        {
            EventStreams.UserInterface.Publish(new OpenStoreEvent());
            
            _levelProgressView.SetLevelValue(context.Level);
            _levelProgressView.SetSprite(context.LevelProgress);
            _scoreView.UpdateView(context.Score);
            _scoreService = context.ScoreService;
            
            _diceHandPresenter.DiceButtonCreated += SubscribeDiceButtonClick;
            _diceHandPresenter.Initialize(_handWithDices);
        }

        private void SubscribeDiceButtonClick(DiceButtonPresenter diceButton)
        {
            var button = diceButton.Button;
            var facesSettings = diceButton.DiceFacesSettings;
            button.onClick.AddListener(() => OpenFacesScreen(facesSettings));
        }

        private void OpenFacesScreen(DiceFacesSettings diceFacesSettings)
        {
            DicesScreen.SetActive(false);
            FacesScreen.SetActive(true);
            
            _diceFacesPresenter.Initialize(diceFacesSettings);
            _diceFacesPresenter.FaceButtonClicked += OpenSpellsScreen;
        }

        private void OpenSpellsScreen(DiceFacesSettings diceFacesSettings, int faceIndex)
        {
            DicesScreen.SetActive(false);
            FacesScreen.SetActive(false);
            SpellsScreen.SetActive(true);
            
            var faceUpgradeService = new FaceUpgradeService(diceFacesSettings, _scoreService);
            _spellsPresenter.Initialize(faceUpgradeService, _scoreService, faceIndex);
        }

        public void OnDisable()
        {
            _diceHandPresenter.DiceButtonCreated -= SubscribeDiceButtonClick;
        }
    }
}