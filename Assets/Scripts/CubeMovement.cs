using UnityEngine;
using System.Collections;

public class CubeMovement : MonoBehaviour
{
    public float moveDistance = 5f; // Distance to move left and right
    public float moveSpeed = 2f;    // Speed of movement

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Save the initial position
        StartCoroutine(MoveCube()); // Start the movement coroutine
    }

    IEnumerator MoveCube()
    {
        while (true) // Loop forever
        {
            // Move to the left
            Vector3 leftPosition = startPosition - new Vector3(moveDistance, 0, 0);
            yield return MoveToPosition(leftPosition);
            yield return new WaitForSeconds(1f); // Wait for 1 second

            // Move to the right
            yield return MoveToPosition(startPosition);
            yield return new WaitForSeconds(1f); // Wait for 1 second
        }
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startingPos = transform.position;

        while (timeElapsed < moveDistance / moveSpeed)
        {
            transform.position = Vector3.Lerp(startingPos, targetPosition, timeElapsed * moveSpeed / moveDistance);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Ensure the position is exactly the target
    }
}
