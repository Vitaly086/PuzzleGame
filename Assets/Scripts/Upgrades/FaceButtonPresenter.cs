using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Upgrades
{
    /// <summary>
    /// Кнопка одной грани - на ней актуальное количество точек
    /// </summary>
    public class FaceButtonPresenter : MonoBehaviour
    {
        [field: SerializeField] public Button Button;
        [SerializeField] private TextMeshProUGUI _valueLabel;

        public void Initialize(int value)
        {
            _valueLabel.text = value.ToString();
        }
    }
}