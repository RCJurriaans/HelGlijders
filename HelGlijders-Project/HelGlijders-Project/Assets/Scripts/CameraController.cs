using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = .1f;
    private Vector3 refVelocity = Vector3.zero;


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref refVelocity, smoothSpeed);
        
        transform.position = smoothedPosition;
    }
}
