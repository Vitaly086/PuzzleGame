using GameCore.Dice;
using TMPro;
using UnityEngine;

/// <summary>
/// Кнопка одного кубика первого окна магазина
/// </summary>
public class DiceButtonPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleLabel;

    public void Initialize(DiceFacesSettings diceFacesSettings, string title)
    {
        _titleLabel.text = title;
    }
}