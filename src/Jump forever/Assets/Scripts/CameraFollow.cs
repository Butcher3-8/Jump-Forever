using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Kamera tarafından takip edilecek karakterin Transform'u
    public float smoothSpeed = 0.125f; // Kameranın ne kadar yumuşak hareket edeceği
    public Vector3 offset; // Karakter ile kamera arasındaki ofset

    void LateUpdate()
    {
        // Hedef pozisyonu, kameranın konumu ve ofset ile hesaplanır
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
