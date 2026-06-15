using System.Collections;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPosition = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int spawnIndex = Random.Range(0, ballPrefabs.Length);

        IEnumerator WaitRandomSeconds()
        {
            yield return new WaitForSeconds(Random.Range(0f, 2.0f));
            // instantiate ball at random spawn location
            Instantiate(ballPrefabs[spawnIndex], spawnPosition, ballPrefabs[spawnIndex].transform.rotation);
        }

        StartCoroutine(WaitRandomSeconds());
    }

}
