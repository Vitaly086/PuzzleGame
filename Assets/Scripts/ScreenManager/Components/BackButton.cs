using JetBrains.Annotations;
using ScreenManager.Core;
using UnityEngine;

namespace ScreenManager.Components
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
