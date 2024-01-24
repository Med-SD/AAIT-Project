using UnityEngine;

public class ChangeMaterialOnTouch : MonoBehaviour
{
    private Renderer handRenderer;
    private Material currentMaterial;

    private void Start()
    {
        handRenderer = GetComponent<Renderer>();
        currentMaterial = handRenderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        Renderer touchedObjectRenderer = other.GetComponent<Renderer>();
        if (touchedObjectRenderer != null)
        {
            currentMaterial = touchedObjectRenderer.material;
            handRenderer.material = currentMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Add any additional logic here if necessary
    }
}
