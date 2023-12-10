using System.Collections;
using ScreenManager.Interfaces;

namespace ScreenManager
{
    public class EmptyAppearingBehaviour : IAppearingScreenBehaviour
    {
        public IEnumerator SetActiveAsync(bool state)
        {
            yield break;
        }
    }
}
