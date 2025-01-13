using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float smashSpeed = 5f;  // Speed at which the cube smashes
    public float backUpSpeed = 2f; // Speed at which the cube backs up
    public float smashDuration = 1f;  // Duration of the rapid smashing
    public float delayBeforeRepeat = 1f; // Time to wait before repeating the smash action

    private bool isSmashing = false;

    void Start()
    {
        // Start the cube behavior (smashing and backing up)
        StartCoroutine(SmashAndBackUpRoutine());
    }

    // Coroutine to handle the smashing and backing up behavior
    IEnumerator SmashAndBackUpRoutine()
    {
        // First smash
        yield return StartCoroutine(SmashToGround());

        // Back up slowly
        yield return StartCoroutine(BackUpSlowly());

        // Repeat smashing rapidly
        while (true)
        {
            yield return StartCoroutine(RapidSmash());
            yield return new WaitForSeconds(delayBeforeRepeat);  // Delay before next smash
        }
    }

    // Coroutine to simulate the initial smash towards the ground
    IEnumerator SmashToGround()
    {
        isSmashing = true;
        float initialY = transform.position.y;

        while (transform.position.y > 0)
        {
            // Move cube downward
            transform.Translate(Vector3.down * smashSpeed * Time.deltaTime);
            yield return null;
        }

        // Ensure the cube hits the ground exactly
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        isSmashing = false;
    }

    // Coroutine to simulate the slow backup movement
    IEnumerator BackUpSlowly()
    {
        float initialZ = transform.position.z;

        while (transform.position.z < initialZ + 5f) // Move the cube back by 5 units
        {
            transform.Translate(Vector3.back * backUpSpeed * Time.deltaTime);
            yield return null;
        }

        // Ensure the cube's backup movement stops exactly
        transform.position = new Vector3(transform.position.x, transform.position.y, initialZ + 5f);
    }

    // Coroutine for the rapid smashing behavior
    IEnumerator RapidSmash()
    {
        float initialY = transform.position.y;

        for (int i = 0; i < 5; i++)  // Smash 5 times rapidly
        {
            // Move cube downwards quickly
            transform.Translate(Vector3.down * smashSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.1f); // Rapid smash interval (you can adjust this)

            // Move cube back up
            transform.Translate(Vector3.up * smashSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.1f); // Rapid upward interval
        }

        // Ensure the cube returns to the initial height after rapid smashing
        transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
    }
}
