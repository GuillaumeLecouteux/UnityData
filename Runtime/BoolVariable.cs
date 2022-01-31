using UnityEngine;

namespace JauntyBear.UnityData
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "Data/BoolVariable")]
    public class BoolVariable : AVariable<bool>
    {
        public void SetValue(BoolVariable value)
        {
            Value = value.Value;
        }

        public void Switch()
        {
            Value = !Value;
        }
    }
}