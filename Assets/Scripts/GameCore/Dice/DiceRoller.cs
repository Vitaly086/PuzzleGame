using JetBrains.Annotations;
using Score;
using UnityEngine;

//TODO: разделить логику и вью?
namespace GameCore.Dice
{
    public class DiceRoller : MonoBehaviour
    {
        [SerializeField]
        private DicePusher _dicePusher;
        [SerializeField] 
        private ScoreController _scoreController;
        [SerializeField] 
        private ScoreView _scoreView;

        private void Awake()
        {
            _scoreController.ScoreChangedEvent += OnScoreChanged;
        }

        private void OnScoreChanged(int currentScore, int newScore)
        {
            _scoreView.UpdateViewGradually(currentScore, newScore);
        }

        [UsedImplicitly]
        public void Roll()
        {
            var dices = _dicePusher.PushDice();
            foreach (var dice in dices)
            {
                dice.Stopped += GetDiceValue;
            }
        }

        private void GetDiceValue(Dice dice)
        {
            dice.Stopped -= GetDiceValue;
        
            float maxDot = 0;
            var faceIndex = 0;

            var faces = dice.DiceFaces;
            var facesRoots = faces.FacesRoots;
            for (var i = 0; i < facesRoots.Length; i++)
            {
                var dot = Vector3.Dot(transform.TransformDirection(facesRoots[i].transform.forward), Vector3.up);
                if (dot > maxDot)
                {
                    maxDot = dot;
                    faceIndex = i;
                }
            }

            var faceValue = faces.DiceFacesSettings.GetValue(faceIndex);
            _scoreController.SetScore(faceValue);
        }

        private void OnDestroy()
        {
            _scoreController.ScoreChangedEvent -= OnScoreChanged;
        }
    }
}