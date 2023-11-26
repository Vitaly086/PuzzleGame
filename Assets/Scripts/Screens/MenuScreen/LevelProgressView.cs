using UnityEngine;
using UnityEngine.UI;

namespace Screens.MenuScreen
{
    public class LevelProgressView : MonoBehaviour
    {
        [SerializeField] private Image _levelBackground;
        [SerializeField] private Sprite _lowProgressSprite;
        [SerializeField] private Sprite _mediumProgressSprite;
        [SerializeField] private Sprite _highProgressSprite;

        public void SetSprite(float currentProgress)
        {
            Debug.LogWarning(currentProgress);
            if (currentProgress > 0.66)
            {
                _levelBackground.sprite = _highProgressSprite;
            }
            else if (currentProgress > 0.33)
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