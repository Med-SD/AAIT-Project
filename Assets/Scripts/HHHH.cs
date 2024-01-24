using System.Collections;
using UnityEngine;

public class GlowingObjectController : MonoBehaviour
{
    [SerializeField] private Color glowColor = Color.white; // Adjust the glow color
    [SerializeField] private float glowIntensity = 1.0f; // Adjust the intensity of the glow
    [SerializeField] private float distance = 1f;
    [SerializeField] private float glowDuration = 2.0f; // Adjust the duration of the glow
    [SerializeField] private Vector3 pos = Vector3.zero;
    [SerializeField] private bool glowing = false;
    private float count = 0f;
    private bool down = false;


    void Update()
    {
        if (count > glowDuration) {
            down = true;
        }
        if (count <= 0)
        {
            down = false;
        }
        if (down)
        {
            count -= Time.deltaTime;
        }
        else
        {
            count += Time.deltaTime;
        }
        if (glowing) {
            SetGlowIntensity((count / glowDuration) * 100);
        } else
        {
            SetUpDown(((count / glowDuration) - 0.5f) * 0.001f);
        }
    }

    void SetGlowIntensity(float intensity)
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            Material originalMaterial = renderer.material;
            Material glowingMaterial = new Material(originalMaterial);

            glowingMaterial.EnableKeyword("_EMISSION");
            glowingMaterial.SetColor("_EmissionColor", glowColor * intensity);

            renderer.material = glowingMaterial;
        }
        else
        {
            Debug.LogWarning("Renderer component not found!");
        }
    }
    void SetUpDown(float intensity)
    {
        transform.position = transform.position + pos * intensity * 10;
    }
}
