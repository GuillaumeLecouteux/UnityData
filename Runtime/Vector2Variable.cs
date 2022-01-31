using UnityEngine;
using System;

namespace JauntyBear.UnityData
{
    [CreateAssetMenu(fileName = "Vector2Variable", menuName = "Data/Vector2Variable")]
    public class Vector2Variable : AVariable<Vector2>
    {
        public void SetValue(Vector2Variable newValue)
        {
            SetValue(newValue.Value);
        }

        public void ApplyChange(Vector2 delta)
        {
            _value += delta;
        }

        public void ApplyChange(Vector2Variable delta)
        {
            _value += delta.Value;
        }
    }
}