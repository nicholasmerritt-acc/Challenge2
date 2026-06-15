using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public InputAction fireAction;
    public float dogSpawnTimeout;
    private float dogSpawnTimeoutAmount = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        fireAction.Enable();
        dogSpawnTimeout = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog if timeout is over
        if (dogSpawnTimeout <= 0 )
        {
            dogSpawnTimeout = 0;
            if (fireAction.triggered)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                dogSpawnTimeout = dogSpawnTimeoutAmount;
            }
        }
        else //time player out so they don't spam dogs
        {
            dogSpawnTimeout -= Time.deltaTime;
        }
    }
}
