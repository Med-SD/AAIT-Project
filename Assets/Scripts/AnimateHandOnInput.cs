using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{

    public InputActionProperty gripAnimationAction;
    public InputActionProperty pincAnimationAction;
    public Animator handAnimator;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pincAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

        float triggerValue2 = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", triggerValue2);
    }
}
