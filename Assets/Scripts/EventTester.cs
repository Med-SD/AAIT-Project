using UnityEngine;
using UnityEngine.Events;

public class EventTester : MonoBehaviour
{

    [System.Serializable]
    public class TriggerExitEventValid : UnityEvent { }

    public TriggerExitEvent OnTriggerExitEventValid;

    [System.Serializable]
    public class TriggerExitEvent : UnityEvent { }

    public TriggerExitEvent OnTriggerExitEvent;

    [System.Serializable]
    public class TriggerEnterEvent : UnityEvent { }

    public TriggerExitEvent OnTriggerEnterEvent;

    private void OnTriggerExit(Collider other)
    {
        playerExit();
        /*if (other.transform.position.z < 9.87f)
        {
            OnTriggerExitEventValid.Invoke(other);
        }*/
    }

    public void playerExit()
    {
        OnTriggerExitEvent.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent.Invoke();
    }
}
