using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Screens.MenuScreen
{
    public class LevelProgressView : MonoBehaviour
    {
        [SerializeField] private Image _levelBackground;
        [SerializeField] private Image _lowProgressSprite;
        [SerializeField] private Image _mediumProgressSprite;
        [SerializeField] private Image _highProgressSprite;
    }
}