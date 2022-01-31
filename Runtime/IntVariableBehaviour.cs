using UnityEngine;
using UnityEngine.Events;

namespace JauntyBear
{
    public class IntVariableBehaviour : MonoBehaviour
    {
        public IntVariable intVariable;
        public bool enableMinOnStart = false;
        public int minOnStart;
        public UnityEvent OnMinResponse;
        public UnityEvent OnMaxResponse;
        public UnityEventInt OnChangeResponse;
        public UnityEventString OnChangeTextResponse;
        public string textFormat = null;
        public bool OnChangeInclusive = false;

        public bool debug;

        public bool setValueOnEnable = false;
        public int valueOnEnable = 0;

        void Start()
        {
            if (enableMinOnStart && intVariable.Value < minOnStart)
                intVariable.SetValue(minOnStart);

        }

        private void OnEnable()
        {
            intVariable.OnVariableChange += OnValueChanged;
            if (setValueOnEnable)
                SetValue(valueOnEnable);
            OnChangeTextResponse?.Invoke(intVariable.Value.ToString(textFormat));
        }

        private void OnDisable()
        {
            intVariable.OnVariableChange -= OnValueChanged;
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

        public void OnValueChanged(int value)
        {
            if (OnChangeInclusive)
            {
                OnChangeResponse?.Invoke(value);
                OnChangeTextResponse?.Invoke(value.ToString(textFormat));
            }

            if (intVariable.MinReached)
            {
                if (debug) DebugExt.Log(name + ".ApplyChange:MinReached");
                OnMinResponse?.Invoke();
            }
            else if (intVariable.MaxReached)
            {
                OnMaxResponse?.Invoke();
            }
            else if (OnChangeInclusive == false)
            {
                if (debug) DebugExt.Log(name + ".ApplyChange:OnChangeResponse");
                OnChangeResponse?.Invoke(value);
                OnChangeTextResponse?.Invoke(value.ToString(textFormat));
            }
        }
    }
}