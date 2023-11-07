using TMPro;
using Zenject;

namespace GameCore.Dice
{
    public class DiceFaceFactory
    {
        private readonly DiContainer _container;
        private readonly DiceFacesProvider _diceFacesProvider;

        public DiceFaceFactory(DiContainer container, DiceFacesProvider diceFacesProvider)
        {
            _container = container;
            _diceFacesProvider = diceFacesProvider;
        }

        public DiceFace GetFace(int value)
        {
            var prefab = _diceFacesProvider.GetFacePrefab(value);
            var face = _container.InstantiatePrefabForComponent<DiceFace>(prefab);

            if (value > 9 && face.TryGetComponent(out TextMeshPro label))
            {
                label.text = value.ToString();
            }

            return face;
        }
    }
}