using UnityEngine;
using UnityEngine.Events;

namespace JauntyBear.UnityData
{
    public class IntVariableBehaviour : MonoBehaviour
    {
        public IntVariable intVariable;
        public bool enableMinOnStart = false;
        public int minOnStart;
        public UnityEvent OnMinResponse;
        public UnityEvent OnMaxResponse;
        public UnityEvent<int> OnChangeResponse;
        public UnityEvent<string> OnChangeTextResponse;
        public string textFormat = null;
        public bool OnChangeInclusive = false;

        public bool setValueOnEnable = false;
        public int valueOnEnable = 0;

        void Start()
        {
            if (enableMinOnStart && intVariable.Value < minOnStart)
                intVariable.SetValue(minOnStart);
        }

        private void OnEnable()
        {
            intVariable.VariableChange += OnVariableChange;
            if (setValueOnEnable)
                SetValue(valueOnEnable);
            OnChangeTextResponse?.Invoke(intVariable.Value.ToString(textFormat));
        }

        private void OnDisable()
        {
            intVariable.VariableChange -= OnVariableChange;
        }

        public void SetValue(int value)
        {
            intVariable.SetValue(value);
        }

        public void Increment()
        {
            ApplyChange(1);
        }

        public void Decrement()
        {
            ApplyChange(-1);
        }

        public void ApplyChange(int value)
        {
            intVariable.ApplyChange(value);
        }

        public void ApplyOppositeChange(int value)
        {
            intVariable.ApplyChange(-value);
        }

        public void OnVariableChange(int value)
        {
            if (OnChangeInclusive)
            {
                OnChangeResponse?.Invoke(value);
                OnChangeTextResponse?.Invoke(value.ToString(textFormat));
            }

            if (intVariable.MinReached)
            {
                OnMinResponse?.Invoke();
            }
            else if (intVariable.MaxReached)
            {
                OnMaxResponse?.Invoke();
            }
            else if (OnChangeInclusive == false)
            {
                OnChangeResponse?.Invoke(value);
                OnChangeTextResponse?.Invoke(value.ToString(textFormat));
            }
        }
    }
}