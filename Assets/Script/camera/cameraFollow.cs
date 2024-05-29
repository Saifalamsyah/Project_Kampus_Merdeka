using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Referensi ke transform player
    public Vector3 offset;    // Offset antara kamera dan player
    public float smoothSpeed = 0.125f; // Kecepatan smoothing kamera
    public float tiltAmount = 2f; // Jumlah condong kamera

    private Movement playerMovement; // Referensi ke script Movement dari player

    private void Start()
    {
        // Mendapatkan referensi ke script Movement pada player
        playerMovement = player.GetComponent<Movement>();
    }

    private void LateUpdate()
    {
        // Posisi target kamera berdasarkan posisi player ditambah offset
        Vector3 desiredPosition = player.position + offset;

        // Menyesuaikan posisi kamera yang smooth
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Mengatur posisi kamera
        transform.position = smoothedPosition;

        // Mencondongkan kamera ke arah player menghadap
        TiltCamera();
    }

    private void TiltCamera()
    {
        if (playerMovement != null)
        {
            Vector3 cameraOffset = offset;

            if (playerMovement.IsFacingRight)
            {
                // Kamera condong ke kanan
                cameraOffset.x = Mathf.Abs(offset.x) + tiltAmount;
            }
            else
            {
                // Kamera condong ke kiri
                cameraOffset.x = -Mathf.Abs(offset.x) - tiltAmount;
            }

            // Menentukan posisi target kamera berdasarkan offset yang disesuaikan
            Vector3 desiredPosition = player.position + cameraOffset;

            // Menentukan posisi kamera yang smooth
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}
