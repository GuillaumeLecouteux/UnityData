using System;
using UnityEngine;

namespace JauntyBear.UnityData
{
    [Serializable]
    public abstract class AVariable<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private T _initialValue;

        public T Value
        {
            get => _value;
            set => SetValue(value);
        }

        public event Action<T> VariableChange;

        [HideInInspector]
        [SerializeField]
        protected T _value = default(T);

        public virtual void SetValue(T newValue)
        {
            if (newValue != null && !_value.Equals(newValue))
            {
                _value = newValue;
                VariableChange?.Invoke(_value);
            }
        }

        public void SetInitialValue(T newInitialValue)
        {
            _initialValue = newInitialValue;
        }

        public void SetValue(AVariable<T> value)
        {
            Value = value.GetValue();
        }

        public T GetValue()
        {
            return Value;
        }

        public void Reset()
        {
            SetValue(_initialValue);
        }

        public void OnAfterDeserialize()
        {
            _value = _initialValue;
        }

        public void OnBeforeSerialize() { }

        public override string ToString()
        {
            return _value.ToString();
        }
		
		public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}