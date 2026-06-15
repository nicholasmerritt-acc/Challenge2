using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -25;
    private float spawnLimitXRight = 12;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnIntervalMin = 3.0f;
    private float spawnIntervalMax = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SpawnRandomBall), startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPosition = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int spawnIndex = Random.Range(0, ballPrefabs.Length);

        Instantiate(ballPrefabs[spawnIndex], spawnPosition, ballPrefabs[spawnIndex].transform.rotation);

        Invoke(nameof(SpawnRandomBall), Random.Range(spawnIntervalMin, spawnIntervalMax));
    }

}
