using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BlackHoleEffect : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;  // Reference to the PostProcessVolume
    public Transform player;                     // Reference to the player character
    public float darkeningDuration = 5f;         // Duration of the darkening effect
    public float killRadius = 5f;                // Radius within which the player dies
    public float blackHoleSpeed = 1f;            // Speed at which the black hole effect spreads

    private ColorGrading colorGrading;
    private Bloom bloom;
    private float timer = 0f;

    private PlayerHealth playerHealth;           // Reference to the player's health script

    void Start()
    {
        // Get the PostProcess components from the volume
        postProcessVolume.profile.TryGetSettings(out colorGrading);
        postProcessVolume.profile.TryGetSettings(out bloom);

        // Set initial values
        colorGrading.saturation.value = 0f;
        colorGrading.postExposure.value = 0f;
        bloom.intensity.value = 0f;

        // Get the player's health script
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        // Gradually darken the world over time
        if (timer < darkeningDuration)
        {
            timer += Time.deltaTime * blackHoleSpeed;
            float progress = timer / darkeningDuration;

            // Darken saturation and exposure
            colorGrading.saturation.value = Mathf.Lerp(0f, -100f, progress);
            colorGrading.postExposure.value = Mathf.Lerp(0f, -2f, progress);
            bloom.intensity.value = Mathf.Lerp(0f, 0.5f, progress);
        }

        // Check the distance between the black hole center (player) and the black hole radius
        if (Vector3.Distance(player.position, transform.position) < killRadius)
        {
            // Kill the player if the black hole is too close
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.Die();  // Call the death method on the player's health script
        }

        // Optionally, you can also stop the game or trigger a Game Over state here
        Debug.Log("Player has been killed by the black hole!");
    }
}
