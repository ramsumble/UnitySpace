using UnityEngine;

public class WrapAround : MonoBehaviour
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

        // Wrap around the screen
        WrapAroundScreen();
    }

    void WrapAroundScreen()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // If the object goes off the right side of the screen, wrap to the left
        if (viewPos.x > 1)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, viewPos.y, viewPos.z));
        }

        // If the object goes off the left side of the screen, wrap to the right
        if (viewPos.x < 0)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1, viewPos.y, viewPos.z));
        }

        // If the object goes off the top side of the screen, wrap to the bottom
        if (viewPos.y > 1)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewPos.x, 0, viewPos.z));
        }

        // If the object goes off the bottom side of the screen, wrap to the top
        if (viewPos.y < 0)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewPos.x, 1, viewPos.z));
        }
    }
}
