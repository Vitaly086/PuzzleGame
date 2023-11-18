using UnityEngine;

namespace GameCore.Dice
{
    [CreateAssetMenu(fileName = "DiceFacesSettings", menuName = "Dice/DiceFacesSettings")]
    public class DiceFacesSettings : ScriptableObject
    {
        [field: SerializeField]
        public DiceFace[] DiceFaces { get; private set; } = new DiceFace[GlobalConstants.DICE_FACE_COUNT];

        public void SetValue(int value, int index)
        {
            DiceFaces[index].Value = value;
        }

        public int GetValue(int index)
        {
            return DiceFaces[index].Value;
        }
    }
}