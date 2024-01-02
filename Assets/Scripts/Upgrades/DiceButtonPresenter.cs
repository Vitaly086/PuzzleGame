using GameCore.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Upgrades
{
    /// <summary>
    /// Кнопка одного кубика первого окна магазина
    /// </summary>
    public class DiceButtonPresenter : MonoBehaviour
    {
        [field: SerializeField] public Button Button;
        [SerializeField] private TextMeshProUGUI _titleLabel;
        public DiceFacesConfig DiceFacesConfig { get; private set; }

        public void Initialize(DiceFacesConfig diceFacesConfig, string title)
        {
            _titleLabel.text = title;
            DiceFacesConfig = diceFacesConfig;
        }
    }
}