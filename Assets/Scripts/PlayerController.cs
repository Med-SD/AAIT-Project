using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [System.Serializable]
    public class InputActionEvent
    {
        public InputActionProperty inputActionProperty;
        public UnityEvent unityEvent;
    }

    [SerializeField] private InputActionEvent[] inputActionEvents;

    private void OnEnable()
    {
        foreach (var inputActionEvent in inputActionEvents)
        {
            inputActionEvent.inputActionProperty.action.Enable();
        }
    }

    private void OnDisable()
    {
        foreach (var inputActionEvent in inputActionEvents)
        {
            inputActionEvent.inputActionProperty.action.Disable();
        }
    }

    private void Start()
    {
        foreach (var inputActionEvent in inputActionEvents)
        {
            inputActionEvent.inputActionProperty.action.performed += context => OnInputActionPerformed(context, inputActionEvent.unityEvent);
        }
    }

    private void OnInputActionPerformed(InputAction.CallbackContext context, UnityEvent unityEvent)
    {
        unityEvent.Invoke();
    }
}
