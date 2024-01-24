using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketCheck : XRSocketInteractor
{
    public GameObject obj;

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable) && interactable.transform.gameObject == obj;
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.transform.gameObject == obj;
    }
}
