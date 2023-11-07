using DefaultNamespace;
using UnityEngine;

namespace GameCore.Dice
{
    [CreateAssetMenu(fileName = "DiceFacesSettings", menuName = "Dice/DiceFacesSettings")]
    public class DiceFacesSettings : ScriptableObject
    {
        [field: SerializeField]
        public DiceFace[] DiceFaces { get; private set; } = new DiceFace[GlobalConstants.DICE_FACE_COUNT];

        public void SetFacesValue(int value, int index)
        {
            DiceFaces[index - 1].Value = value;
        }

        public int GetFacesValue(int index)
        {
            return DiceFaces[index - 1].Value;
        }
    }
}