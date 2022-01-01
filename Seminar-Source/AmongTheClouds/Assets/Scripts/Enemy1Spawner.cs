using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Spawner : MonoBehaviour
{
    public GameObject Enemy1GO;

    float maxSpawnRateInSeconds = 35f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(Enemy1GO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //slj. neprijatelj

        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }

        else
            spawnInNSeconds = 1f;

        Invoke("SpawnEnemy", spawnInNSeconds);
    }

    //mijenjanje difficulty igre

    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }

    public void ScheduleEnemySpawner()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        //brze spawnanje svako pola minute
        InvokeRepeating("IncreaseSpawnRate", 0f, 25f);
    }


    //zaustavi spawnanje
    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}