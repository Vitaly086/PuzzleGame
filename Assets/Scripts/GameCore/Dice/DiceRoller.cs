using GameCore.Dice;
using JetBrains.Annotations;
using Score;
using UnityEngine;

//TODO: разделить логику и вью?
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
        foreach (var physicDice in dices)
        {
            physicDice.Stopped += GetDiceValue;
        }
    }

    private void GetDiceValue(PhysicDice physicDice)
    {
        physicDice.Stopped -= GetDiceValue;
        
        var dice = physicDice.GetComponent<Dice>();
            
        float maxDot = 0;
        var faceIndex = 0;

        var faces = dice.FacesRoot;
        for (var i = 0; i < faces.Length; i++)
        {
            var dot = Vector3.Dot(transform.TransformDirection(faces[i].transform.forward), Vector3.up);
            if (dot > maxDot)
            {
                maxDot = dot;
                faceIndex = i;
            }
        }

        var faceValue = dice.DiceFacesSettings.GetValue(faceIndex);
        _scoreController.SetScore(faceValue);
    }

    private void OnDestroy()
    {
        _scoreController.ScoreChangedEvent -= OnScoreChanged;
    }
}