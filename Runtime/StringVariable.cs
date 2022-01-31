using UnityEngine;

namespace JauntyBear.UnityData
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "Data/StringVariable")]
    public class StringVariable : AVariable<string>
    {
        public string Lowercase => Value.ToLower();
        public string Uppercase => Value.ToUpper();

        protected void OnEnable()
        {
            if (_value == null || _value == "")
            {
                _value = string.Empty;
            }
        }
        
        public void SetValue(StringVariable newValue)
        {
            Value = newValue.Value;
        }

        public override bool Equals(System.Object obj) 
        {
            if (obj == null)
                return false;
            StringVariable c = obj as StringVariable ;
            if ((System.Object)c == null)
                return false;
            return _value == c._value;
        }

        public bool Equals(StringVariable c)
        {
            if ((object)c == null)
                return false;
            return _value == c._value;
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}