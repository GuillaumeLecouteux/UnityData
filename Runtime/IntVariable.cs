using UnityEngine;

namespace JauntyBear.UnityData
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "Data/IntVariable")]
    public class IntVariable : AVariable<int>
    {
        public bool hasMinValue = false;
        public int minValue;
        public bool hasMaxValue = false;
        public int maxValue;

        public bool MinReached => hasMinValue?Value<=minValue:false;
        public bool MaxReached => hasMaxValue?Value>=maxValue:false;
        
        public override void SetValue(int newValue)
        {
            int tempValue = newValue;
            if(hasMinValue)
            {
                tempValue = Mathf.Max(tempValue,minValue);
            }
            if(hasMaxValue)
            {
                tempValue = Mathf.Min(tempValue,maxValue);
            }
            base.SetValue(tempValue);
        }
        public void SetValue(IntVariable value)
        {
            Value = value.Value;
        }

        public void ApplyChange(int amount)
        {
            Value += amount;
        }

        public void ApplyChange(IntVariable amount)
        {
            Value += amount.Value;
        }

        public void Increment()
        {
            ApplyChange(1);
        }

        public void Decrement()
        {
            ApplyChange(-1);
        }
    }
}