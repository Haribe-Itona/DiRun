using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxEffect = 0.5f;
    private Vector3 lastCameraPos;

    void Start()
    {
        lastCameraPos = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cameraTransform.position - lastCameraPos;
        transform.position += new Vector3(delta.x * parallaxEffect, 0, 0);
        lastCameraPos = cameraTransform.position;
    }
}