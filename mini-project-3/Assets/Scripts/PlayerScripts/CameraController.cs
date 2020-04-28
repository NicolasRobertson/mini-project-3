using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 30.0f;
    public float offset = 0;

    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + offset, transform.position.z);
    }
}