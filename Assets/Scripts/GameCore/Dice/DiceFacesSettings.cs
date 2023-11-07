using DefaultNamespace;
using UnityEngine;

namespace GameCore.Dice
{
    [CreateAssetMenu(fileName = "DiceFacesSettings", menuName = "Dice/Faces Settings")]
    public class DiceFacesSettings : ScriptableObject
    {
        [field: SerializeField]
        public int[] DiceFacesValues { get; private set; } = new int[GlobalConstants.DICE_FACE_COUNT];

        public void SetFacesValue(int value, int index)
        {
            DiceFacesValues[index - 1] = value;
        }

        public int GetFacesValue(int index)
        {
            return DiceFacesValues[index - 1];
        }
    }
}