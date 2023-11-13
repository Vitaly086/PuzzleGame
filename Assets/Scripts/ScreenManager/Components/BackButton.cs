using JetBrains.Annotations;
using UnityEngine;

namespace ScreenManager.Loaders.Scenes
{
    public class BackButton : MonoBehaviour
    {
        [UsedImplicitly]
        public void Back()
        {
            ScreensManager.Back();
        }
    }
}
