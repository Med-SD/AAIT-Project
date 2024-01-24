using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class HandAnimation : MonoBehaviour
{
    [SerializeField] private InputActionProperty gripAnimationAction;
    [SerializeField] private InputActionProperty triggerAnimationAction;
    [SerializeField] private InputActionProperty pincAnimationAction;
    [SerializeField] private Animator handAnimator;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = triggerAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

        float triggerValue2 = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", triggerValue2);

        float triggerValue3 = pincAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Pinch", triggerValue3);
    }
}
