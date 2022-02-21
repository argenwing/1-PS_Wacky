using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballspawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBall;

    // Ball spawn support
    Timer spawnTimerDelay;
    float spawnRange;

    // Collision free support
    bool retrySpawn = false;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate collsion area
        GameObject tempBall = Instantiate<GameObject>(prefabBall);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballHalfWidth = collider.size.x / 2;
        float ballHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(tempBall.transform.position.x - ballHalfWidth,
            tempBall.transform.position.y - ballHalfHeight);
        spawnLocationMax = new Vector2(tempBall.transform.position.x + ballHalfWidth,
            tempBall.transform.position.y + ballHalfHeight);
        Destroy(tempBall);


        spawnRange = ConfigurationUtils.MaxSpawnSeconds - ConfigurationUtils.MinSpawnSeconds;
        spawnTimerDelay = gameObject.AddComponent<Timer>();
        spawnTimerDelay.AddTimerFinishedListener(HandleSpawnTimerFinished);
        spawnTimerDelay.Duration = SpawnDelay();
        spawnTimerDelay.Run();

        EventManager.AddBallDiedListener(SpawnBall);
        EventManager.AddReduceBallListener(SpawnBall);

        // First Ball in the game
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {

        if (retrySpawn)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        retrySpawn = false;
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            AudioManager.Play(AudioClipName.BallSpawn);
            Instantiate(prefabBall);

        } else
        {
            retrySpawn = true;
        }
        
    }

    float SpawnDelay()
    {
        return ConfigurationUtils.MinSpawnSeconds + (Random.value * spawnRange);
    }

    void HandleSpawnTimerFinished()
    {
        SpawnBall();
        spawnTimerDelay.Duration = SpawnDelay();
        spawnTimerDelay.Run();
    }
}
