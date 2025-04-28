using UnityEngine;

public class OptimizedCable : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    private LineRenderer lineRenderer;

    void Start()
    {
        // Get the LineRenderer component from this GameObject
        lineRenderer = GetComponent<LineRenderer>();

        // Set the number of positions (start and end)
        lineRenderer.positionCount = 2;

        // Set the cable width (same at start and end)
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;

        // Use world space so the cable connects actual world positions
        lineRenderer.useWorldSpace = true;

        // Optionally set the color of the cable
        // lineRenderer.material.color = Color.green;
    }

    void Update()
    {
        // If both points exist, update the cable positions
        if (startPoint != null && endPoint != null)
        {
            lineRenderer.SetPosition(0, startPoint.position);
            lineRenderer.SetPosition(1, endPoint.position);
        }
    }
}

