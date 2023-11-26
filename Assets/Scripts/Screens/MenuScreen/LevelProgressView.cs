using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.MenuScreen
{
    public class LevelProgressView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelLabel;
        [SerializeField] private Image _levelBackground;
        [SerializeField] private Sprite _lowProgressSprite;
        [SerializeField] private Sprite _mediumProgressSprite;
        [SerializeField] private Sprite _highProgressSprite;

        public void SetLevelValue(int value)
        {
            _levelLabel.text = value.ToString();
        }
        
        public void SetSprite(float currentProgress)
        {
            if (currentProgress > 0.67)
            {
                _levelBackground.sprite = _highProgressSprite;
            }
            else if (currentProgress > 0.34)
            {
                _levelBackground.sprite = _mediumProgressSprite;
            }
            else
            {
                _levelBackground.sprite = _lowProgressSprite;
            }
            
            _levelBackground.fillAmount = currentProgress;
        }
    }
}