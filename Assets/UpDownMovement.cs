using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float speed = 2.0f; // Adjust this value to control the speed of the movement
    public float height = 0.5f; // Adjust this value to control the height of the movement

    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        // Use a sine function to create the up and down movement
        float newY = startingPosition.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
