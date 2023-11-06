using UnityEngine;
using Zenject;

namespace Environment
{
    public class CameraFoVAdjuster
    {
        private const float TARGET_ASPECT = 9f / 16f;
        private Camera _cameraComponent;

        [Inject]
        private void Construct(Camera camera)
        {
            _cameraComponent = camera;
            AdjustFoV();
        }

        private void AdjustFoV()
        {
            var windowAspect = Screen.width / (float)Screen.height;
            var scaleHeight = windowAspect / TARGET_ASPECT;

            if (scaleHeight < 1.0f)
            {
                var rect = _cameraComponent.rect;

                rect.width = 1.0f;
                rect.height = scaleHeight;
                rect.x = 0;
                rect.y = (1.0f - scaleHeight) / 2.0f;

                _cameraComponent.rect = rect;
            }
            else
            {
                var scaleWidth = 1.0f / scaleHeight;

                var rect = _cameraComponent.rect;

                rect.width = scaleWidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scaleWidth) / 2.0f;
                rect.y = 0;

                _cameraComponent.rect = rect;
            }
        }
    }
}