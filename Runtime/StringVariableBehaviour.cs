using UnityEngine;
using UnityEngine.Events;

namespace JauntyBear.UnityData
{
    public class StringVariableBehaviour : MonoBehaviour
    {
        [SerializeField] StringVariable variable;

        [SerializeField] UnityEvent<string> OnEnableEvent;
        [SerializeField] UnityEvent<string> ValueChangeEvent;

        void OnEnable()
        {
            OnEnableEvent?.Invoke(variable.Value);
            variable.VariableChange += OnVariableChange;
        }

        void OnDisable()
        {
            variable.VariableChange -= OnVariableChange;
        }

        private void OnVariableChange(string obj)
        {
            ValueChangeEvent?.Invoke(obj);
        }
    }
}