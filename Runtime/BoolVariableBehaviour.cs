using UnityEngine;
using UnityEngine.Events;

namespace JauntyBear.UnityData
{
    public class BoolVariableBehaviour : MonoBehaviour
    {
        [SerializeField] BoolVariable boolVariable;

        [SerializeField] UnityEvent ResponseOnTrue;
        [SerializeField] UnityEvent ResponseOnFalse;

        private void OnEnable()
        {
            OnVariableChange(boolVariable.Value);
            boolVariable.VariableChange += OnVariableChange;
        }

        void OnDisable()
        {
            boolVariable.VariableChange -= OnVariableChange;
        }

        public void SetValue(bool value)
        {
            boolVariable.SetValue(value);
        }

        public void OnVariableChange(bool newValue)
        {
            if (newValue)
                ResponseOnTrue.Invoke();
            else
                ResponseOnFalse.Invoke();

        }
    }
}