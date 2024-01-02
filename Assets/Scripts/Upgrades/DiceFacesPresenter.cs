using System;
using System.Collections.Generic;
using GameCore.Settings;
using UnityEngine;
using UnityEngine.Events;

namespace Upgrades
{
    /// <summary>
    /// Второе окно магазина - в котором все грани одного кубика
    /// </summary>
    public class DiceFacesPresenter : MonoBehaviour
    {
        public event Action<DiceFacesConfig, int> FaceButtonClicked;
        [SerializeField]
        private FaceButtonPresenter[] facesPresenters;
        private DiceFacesConfig _diceFacesConfig;
        private readonly List<FaceButtonPresenter> _faceButtonPresenters = new();
        private readonly List<UnityAction> _faceButtonActions = new(); // Список для хранения действий

        public void Initialize(DiceFacesConfig diceFacesConfig)
        {
            _diceFacesConfig = diceFacesConfig;
        }

        private void OnEnable()
        {
            _faceButtonPresenters.Clear();
            SetFacesValues();
        }

        private void SetFacesValues()
        {
            var faces = _diceFacesConfig.DiceFaces;

            for (var i = 0; i < facesPresenters.Length; i++)
            {
                var facePresenter = facesPresenters[i];
                facePresenter.Initialize(faces[i].Value);

                _faceButtonPresenters.Add(facePresenter);

                var index = i;
                UnityAction action = () => OnFaceButtonClicked(index);
                facePresenter.Button.onClick.AddListener(action);
                _faceButtonActions.Add(action); // Сохраняем действие
            }
        }

        private void OnFaceButtonClicked(int index)
        {
            FaceButtonClicked?.Invoke(_diceFacesConfig, index);
        }

        private void OnDisable()
        {
            for (var i = 0; i < _faceButtonPresenters.Count; i++)
            {
                var facePresenter = _faceButtonPresenters[i];
                var action = _faceButtonActions[i];
                facePresenter.Button.onClick.RemoveListener(action);
            }

            _faceButtonPresenters.Clear();
            _faceButtonActions.Clear(); // Очищаем список действий
        }
    }
}