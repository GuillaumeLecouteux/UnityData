using UnityEngine;

namespace JauntyBear.UnityData
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Data/FloatVariable")]
    public class FloatVariable : AVariable<float>
    {
        public void SetValue(FloatVariable value)
        {
            Value = value.Value;
        }

        public void ApplyChange(float amount)
        {
            Value += amount;
        }

        public void ApplyChange(FloatVariable amount)
        {
            Value += amount.Value;
        }
    }
}