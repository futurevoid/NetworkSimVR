using UnityEngine;

public class CableElectricity : MonoBehaviour
{
    public Material cableMaterial;  // The material applied to the cable
    public float speed = 1f;        // Speed of color change (how fast the electricity effect moves)
    private Color startColor;       // The original color of the cable's emission
    private Color endColor;         // The final color (electric color, like bright blue)

    void Start()
    {
        // Get the original emission color from the material
        startColor = cableMaterial.GetColor("_EmissionColor");
        
        // Set the final color (for example, a bright cyan blue to simulate electricity)
        endColor = new Color(0.0f, 0.5f, 1.0f); // Cyan blue
    }

    void Update()
    {
        // Create a pulsing effect by changing the color over time
        // Mathf.PingPong makes the color oscillate back and forth between the start and end color
        float lerpTime = Mathf.PingPong(Time.time * speed, 1);
        
        // Lerp (Linear Interpolation) between the start and end colors based on the time
        Color currentColor = Color.Lerp(startColor, endColor, lerpTime);
        
        // Update the emission color of the material with the new color
        cableMaterial.SetColor("_EmissionColor", currentColor);
    }
}
