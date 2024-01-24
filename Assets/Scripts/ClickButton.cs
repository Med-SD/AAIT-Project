using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickButton : MonoBehaviour
{
    [SerializeField] private InputActionProperty pincAnimationAction;
    [SerializeField] private LineRenderer lineRenderer;
    public void ClickButtonSpeed()
    {
        float pincValue = pincAnimationAction.action.ReadValue<float>();
        Debug.Log(pincValue);
        if (pincValue >= 1f) {
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    void Update()
    {
        if (this.transform.parent.GetComponent<IsObjectSelected>().selected)
        {
            float pincValue = pincAnimationAction.action.ReadValue<float>();
            if (pincValue >= 0.5f)
            {
                lineRenderer.enabled = true;
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
    }

}
