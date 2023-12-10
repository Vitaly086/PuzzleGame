using GameCore.Dice;
using UnityEngine;
/// <summary>
/// Первое окно магазина - в котором все кубики и покупка кубика
/// </summary>
public class DiceHandPresenter : MonoBehaviour
{
    [SerializeField] private Transform _root;
    [SerializeField] private DiceFacesSettings _defaultSettings;
    [SerializeField] private DiceButtonPresenter _diceButtonPrefab;
    [SerializeField] private HandWithDices _handWithDices; // Пока захардкожено

    public void Initialize()
    {
        var dicesSettings = _handWithDices.GetDices();
        for (var i = 0; i < dicesSettings.Count; i++)
        {
            var diceButton = Instantiate(_diceButtonPrefab, _root);
            diceButton.Initialize(dicesSettings[i], (i + 1).ToString());
        }
        
        var creationNewDiceButton = Instantiate(_diceButtonPrefab, _root);
        
        _handWithDices.AddDice();
        creationNewDiceButton.Initialize(_defaultSettings, "+");
    }
}