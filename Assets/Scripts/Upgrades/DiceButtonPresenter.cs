using GameCore.Dice;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Кнопка одного кубика первого окна магазина
/// </summary>
public class DiceButtonPresenter : MonoBehaviour
{
    [field: SerializeField] public Button Button;
    [SerializeField] private TextMeshProUGUI _titleLabel;
    public DiceFacesSettings DiceFacesSettings { get; private set; }

    public void Initialize(DiceFacesSettings diceFacesSettings, string title)
    {
        _titleLabel.text = title;
        DiceFacesSettings = diceFacesSettings;
    }
}