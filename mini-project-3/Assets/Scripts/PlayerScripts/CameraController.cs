using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 30.0f;
    public float horizontalView = 120f;
    public float offset = 0;

    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + offset, transform.position.z);
        Camera.main.fieldOfView = calculateVerticalFieldOfView(horizontalView, Camera.main.aspect);
    }

    public float calculateVerticalFieldOfView(float screenHeightInDeg, float aspectRatio)
    {
        float screenHeightInRad = screenHeightInDeg * Mathf.Deg2Rad;
        float verticalViewInRad = 2 * Mathf.Atan(Mathf.Tan(screenHeightInRad / 2) / aspectRatio);
        float verticalFieldOfView = verticalViewInRad * Mathf.Rad2Deg;
        return verticalFieldOfView;
    }
}