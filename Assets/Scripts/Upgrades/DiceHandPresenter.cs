using System;
using GameCore.Dice;
using UnityEngine;

/// <summary>
/// Первое окно магазина - в котором все кубики и покупка кубика
/// </summary>
public class DiceHandPresenter : MonoBehaviour
{
    public event Action<DiceButtonPresenter> DiceButtonCreated; 
    [SerializeField] private Transform _root;
    [SerializeField] private DiceFacesSettings _defaultSettings;
    [SerializeField] private DiceButtonPresenter _diceButtonPrefab;
    private HandWithDices _handWithDices;
    private DiceButtonPresenter _creationNewDiceButton;
    
    public void Initialize(HandWithDices handWithDices)
    {
        _handWithDices = handWithDices;
        var dicesSettings = handWithDices.GetDices();
        for (var i = 0; i < dicesSettings.Count; i++)
        {
            var diceButton = Instantiate(_diceButtonPrefab, _root);
            diceButton.Initialize(dicesSettings[i], (i + 1).ToString());
            DiceButtonCreated?.Invoke(diceButton);
        }
        
        _creationNewDiceButton = Instantiate(_diceButtonPrefab, _root);
        _creationNewDiceButton.Initialize(_defaultSettings, "+");
        _creationNewDiceButton.Button.onClick.AddListener(AddDiceToHand);
    }

    private void AddDiceToHand()
    {
        _handWithDices.AddDice();
    }

    private void OnDisable()
    {
        _creationNewDiceButton.Button.onClick.RemoveListener(AddDiceToHand);
    }
}