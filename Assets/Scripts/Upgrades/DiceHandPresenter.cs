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
    
    public void Initialize(HandWithDices handWithDices)
    {
        var dicesSettings = handWithDices.GetDices();
        for (var i = 0; i < dicesSettings.Count; i++)
        {
            var diceButton = Instantiate(_diceButtonPrefab, _root);
            diceButton.Initialize(dicesSettings[i], (i + 1).ToString());
            DiceButtonCreated?.Invoke(diceButton);
        }
        
        var creationNewDiceButton = Instantiate(_diceButtonPrefab, _root);
        
        handWithDices.AddDice();
        creationNewDiceButton.Initialize(_defaultSettings, "+");
    }
}