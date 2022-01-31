using UnityEngine;
using System;

namespace JauntyBear.UnityData
{
    [CreateAssetMenu(fileName = "Vector3Variable", menuName = "Data/Vector3Variable")]
    public class Vector3Variable : AVariable<Vector3>
    {
        public void SetValue(Vector3Variable newValue)
        {
            SetValue(newValue.Value);
        }

        public void ApplyChange(Vector3 delta)
        {
            _value += delta;
        }

        public void ApplyChange(Vector3Variable delta)
        {
            _value += delta.Value;
        }
    }
}