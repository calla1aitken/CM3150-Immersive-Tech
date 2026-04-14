using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float radius = 5f;
    [SerializeField] int subdivisions = 10;

    void MakeCircle()

    {
        float angleStep = 2f * Mathf.PI / subdivisions;
        lineRenderer.positionCount = subdivisions;



        for (int i = 0; i < subdivisions; i++)
        {
            float xPosition = radius * Mathf.Cos(angleStep * i);
            float yPosition = radius * Mathf.Sin(angleStep * i);

            Vector3 pointInCircle = new Vector3(xPosition, yPosition, 0f);
            lineRenderer.SetPosition(i, pointInCircle);
        }
    }

    private void Start()
    {
        MakeCircle();
    }
}
