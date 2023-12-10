using System.Collections;

namespace ScreenManager.Interfaces
{
    public interface IAppearingScreenBehaviour
    {
        IEnumerator SetActiveAsync(bool state);
    }
}
