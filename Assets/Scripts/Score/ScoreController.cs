using System;
using UnityEngine;

namespace Score
{
    public class ScoreController : MonoBehaviour
    {
        public Action<int, int> ScoreChangedEvent;
        
        [field: SerializeField]
        public int Value { get; private set; }

        public void SetScore(int value)
        {
            var currentScore = Value;
            Value += value;
            ScoreChangedEvent?.Invoke(currentScore, Value);
        }

        public bool TryBuy(int price)
        {
            if (Value >= price)
            {
                Value -= price;
                ScoreChangedEvent?.Invoke(Value, Value);
                return true;
            }

            return false;
        }
    }
}