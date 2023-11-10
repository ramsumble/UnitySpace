using UnityEngine;

public class RotateAndMove : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float moveSpeed = 5f;

    void Update()
    {
        // Rotation
        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * rotationInput * rotationSpeed * Time.deltaTime);

        // Forward and backward movement
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * moveSpeed * Time.deltaTime);
    }
}
