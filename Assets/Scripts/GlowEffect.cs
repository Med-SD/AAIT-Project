using UnityEngine;

public class ShinyObject : MonoBehaviour
{
    public float glowSpeed = 1f;
    public float minIntensity = 1f;
    public float maxIntensity = 5f;

    private Material material;
    private float currentIntensity = 1f;
    private bool increasing = true;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // Check if the object already has a material; if not, create a new one
            if (renderer.material == null)
            {
                material = CreateMaterial();
                renderer.material = material;
            }
            else
            {
                material = renderer.material;
            }
        }
        else
        {
            Debug.LogError("ShinyObject script requires a Renderer component on the GameObject.");
            enabled = false; // Disable the script to avoid errors
        }
    }

    Material CreateMaterial()
    {
        // Create a new material with the appropriate shader
        Material newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.name = "ShinyMaterial";
        newMaterial.EnableKeyword("_EMISSION");
        newMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;

        return newMaterial;
    }

    void Update()
    {
        UpdateGlow();
    }

    void UpdateGlow()
    {
        if (increasing)
        {
            currentIntensity += glowSpeed * Time.deltaTime;
            if (currentIntensity >= maxIntensity)
            {
                currentIntensity = maxIntensity;
                increasing = false;
            }
        }
        else
        {
            currentIntensity -= glowSpeed * Time.deltaTime;
            if (currentIntensity <= minIntensity)
            {
                currentIntensity = minIntensity;
                increasing = true;
            }
        }

        // Apply the glow effect to the material
        Color emissionColor = Color.white * Mathf.LinearToGammaSpace(currentIntensity);
        material.SetColor("_EmissionColor", emissionColor);
    }
}
