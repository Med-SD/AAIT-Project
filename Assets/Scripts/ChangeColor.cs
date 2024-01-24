using UnityEngine;

public class OpacityChange : MonoBehaviour
{
    public float fadeDuration = 2.0f; // Time taken for one complete fade cycle
    public Material targetMaterial;   // Reference to the material you want to change

    private void Start()
    {
        // Validate that a material is assigned
        if (targetMaterial == null)
        {
            Debug.LogError("Target material is not assigned!");
            enabled = false; // Disable the script if the material is not assigned
            return;
        }

        // Call the Fade function repeatedly
        InvokeRepeating("Fade", 0f, fadeDuration);
    }

    private void Fade()
    {
        StartCoroutine(FadeCoroutine());
    }

    private System.Collections.IEnumerator FadeCoroutine()
    {
        float elapsedTime = 0f;
        Color startColor = targetMaterial.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f); // Fully transparent

        while (true)
        {
            if(elapsedTime > fadeDuration) {
                elapsedTime = 0f;
            }
            targetMaterial.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final color is set
        targetMaterial.color = endColor;
    }
}
