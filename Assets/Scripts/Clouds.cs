using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float speed = 1.0f; // Adjust this to control the speed of the clouds
    public float resetPosition = 10.0f; // The position where the clouds will reset to continue looping

    void Update()
    {
        // Move the clouds to the right
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Check if the cloud has moved past the reset position
        if (transform.position.x > resetPosition)
        {
            // If the cloud has moved past the reset position, reset its position to the left
            Vector3 newPosition = transform.position;
            newPosition.x = -resetPosition;
            transform.position = newPosition;
        }
    }
}