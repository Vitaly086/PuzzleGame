using Events;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace GameCore.Dice
{
    public class DiceRoller : MonoBehaviour
    {
        private DicePusher _dicePusher;

        [Inject]
        private void Construct(DicePusher dicePusher)
        {
            _dicePusher = dicePusher;
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

            var facesRoots = dice.GetFacesRoot();
            for (var i = 0; i < facesRoots.Length; i++)
            {
                var dot = Vector3.Dot(transform.TransformDirection(facesRoots[i].transform.forward), Vector3.up);
                if (dot > maxDot)
                {
                    maxDot = dot;
                    faceIndex = i;
                }
            }
            
            var faceValue = dice.GetFaceValue(faceIndex);
            EventStreams.UserInterface.Publish(new DiceRollCompletedEvent(faceValue));
        }
    }
}