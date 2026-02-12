using UnityEngine;
using UnityEngine.Splines;

public class WaveSpawnHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CoreHandler core;

    public GameObject debugBaseEnemyToSpawn;

    public SplineContainer splinePath;

    public Camera currentcamera;

    private bool waveActive = false;

    public int numEnemiesToSpawn = 15;

    private int numInstancedEnemies = 0;

    public float spawnInterval = 3.0f;

    private float deltaTracker = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(waveActive)
        {
            deltaTracker += Time.deltaTime;
        }
        else
        {
            deltaTracker = 0.0f;
            numInstancedEnemies = 0;
        }

        if (deltaTracker >= spawnInterval && numInstancedEnemies < numEnemiesToSpawn)
        {
            numInstancedEnemies += 1;
            SpawnEnemy();
            deltaTracker = 0.0f;
        }
        else if(numInstancedEnemies >= numEnemiesToSpawn)
        {
            StopWave();
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy_instance = Instantiate(debugBaseEnemyToSpawn, transform.position, Quaternion.identity);
        print("Enemy instance is " + enemy_instance);
        BaseEnemy base_enemy_instance = enemy_instance.GetComponent<BaseEnemy>();
        enemy_instance.GetComponent<SplineAnimate>().Container = splinePath;
        //enemy_instance.GetComponent<BillBoardUI>().currentCamera = currentcamera;
        base_enemy_instance.billBoardUI.currentCamera = currentcamera;
        base_enemy_instance.Reached_End_Of_Path += core.TakeDamage;
        base_enemy_instance.StartMoving();
    }

    public void StartWave()
    {
        waveActive = true;
    }
    public void StopWave()
    {
        waveActive = false;
    }
}
