using System.Collections;
using TMPro;
using UnityEngine;

namespace Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _valueLabel;
        [SerializeField] 
        private float _scoreChangingDuration = 0.2f;

        private Coroutine _scoreCoroutine;
        
        public void UpdateView(int value)
        {
            _valueLabel.text = value.ToString();
        }
    
        public void UpdateViewGradually(int currentScore, int newScore)
        {
            if (_scoreCoroutine != null)
            {
                // Обновление счета до его последнего значения перед началом новой интерполяции.
                _valueLabel.text = currentScore.ToString();
                StopCoroutine(_scoreCoroutine);
            }

            _scoreCoroutine = StartCoroutine(UpdateScore(currentScore, newScore));
        }

        private IEnumerator UpdateScore(int currentScore, int targetScore)
        {
            var currentTime = 0f;

            while (currentTime < _scoreChangingDuration)
            {
                currentScore = (int)Mathf.Lerp(currentScore, targetScore, currentTime / _scoreChangingDuration);
                _valueLabel.text = currentScore.ToString();
                currentTime += Time.deltaTime;
                yield return null;
            }

            _valueLabel.text = targetScore.ToString();
        }
    }
}