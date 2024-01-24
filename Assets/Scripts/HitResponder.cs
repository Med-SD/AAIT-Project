using System;
using UnityEngine;
using UnityEngine.Events;

public class HitResponder : MonoBehaviour
{
    [System.Serializable]
    public class HitEvent : UnityEvent<Vector3>
    {
        internal bool ContainsListener(Action<Vector3> handleRaycastHit)
        {
            throw new NotImplementedException();
        }
    }

    public HitEvent onHitByRaycast;


    void Start()
    {
        if (onHitByRaycast == null)
        {
            onHitByRaycast = new HitEvent();
        }
    }

    // Method to be called when hit by raycast
    public void HandleRaycastHit(Vector3 hitPoint)
    {
        onHitByRaycast.Invoke(hitPoint);
    }
}
