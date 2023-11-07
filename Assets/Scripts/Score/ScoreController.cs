using System;
using UnityEngine;

namespace Score
{
    public class ScoreController : MonoBehaviour
    {
        public Action<int, int> ScoreChangedEvent;
        private int _value;

        public void SetScore(int value)
        {
            var currentScore = _value;
            _value += value;
            ScoreChangedEvent?.Invoke(currentScore, _value);
        }

        public bool TryBuy(int price)
        {
            if (_value >= price)
            {
                _value -= price;
                ScoreChangedEvent?.Invoke(_value, _value);
                return true;
            }

            return false;
        }
    }
}