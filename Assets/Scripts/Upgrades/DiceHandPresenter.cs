using System;
using GameCore.Dice;
using GameCore.DiceDatas;
using GameCore.Settings;
using UnityEngine;

namespace Upgrades
{
    /// <summary>
    /// Первое окно магазина - в котором все кубики и покупка кубика
    /// </summary>
    public class DiceHandPresenter : MonoBehaviour
    {
        public event Action<DiceButtonPresenter> DiceButtonCreated;
        [SerializeField] private Transform _root;
        [SerializeField] private DiceButtonPresenter _diceButtonPrefab;
        private HandWithDices _handWithDices;
        private DiceButtonPresenter _creationNewDiceButton;
        
        public void Initialize(HandWithDices handWithDices, DiceDataManager diceDataManager)
        {
            _handWithDices = handWithDices;
            var dicesSettings = handWithDices.Dices;
            for (var i = 0; i < dicesSettings.Count; i++)
            {
               CreateDiceButton(dicesSettings[i], (i + 1).ToString());
            }
        
            _creationNewDiceButton = Instantiate(_diceButtonPrefab, _root);
            var defaultDiceSettings = diceDataManager.CreateDefaultDiceSettings();
            _creationNewDiceButton.Initialize(defaultDiceSettings, "+");
            _creationNewDiceButton.Button.onClick.AddListener(AddDiceToHand);
        }

        private void AddDiceToHand()
        {
            var newDiceSettings = _handWithDices.AddNewDice();
            CreateDiceButton(newDiceSettings, _handWithDices.Dices.Count.ToString());
            _creationNewDiceButton.transform.SetAsLastSibling();
        }
        
        private void CreateDiceButton(DiceFacesConfig diceSettings, string label)
        {
            var diceButton = Instantiate(_diceButtonPrefab, _root);
            diceButton.Initialize(diceSettings, label);
            DiceButtonCreated?.Invoke(diceButton);
        }

        private void OnDisable()
        {
            _creationNewDiceButton.Button.onClick.RemoveListener(AddDiceToHand);
        }
    }
}