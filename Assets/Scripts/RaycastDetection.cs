using UnityEngine;


public class RaycastDetection : MonoBehaviour
{
    [SerializeField] private string tags;
    [SerializeField] private Vector3 customTransform = Vector3.forward; // Custom transform for ray direction
    [SerializeField] private Transform customPosition; // Custom position for ray origin
    private LineRenderer lineRenderer; // Custom position for ray origin

    private void Start()
    {
        customTransform = transform.forward;
        lineRenderer = GetComponent<LineRenderer>();
    }


    void Update()
    {
        if (this.transform.parent.GetComponent<IsObjectSelected>().selected && lineRenderer.enabled)
        {
            Ray ray = new Ray(customPosition.position, transform.forward);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && tags.Contains(hit.collider.tag))
                {
                    HitResponder hitResponder = hit.transform.GetComponent<HitResponder>();
                
                    if (hitResponder != null)
                    {
                        hitResponder.HandleRaycastHit(hit.point);
                    }
                
            }
        }
    }
}
