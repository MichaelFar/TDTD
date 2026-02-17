using UnityEngine;
using UnityEngine.Events;
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

    private int currentWaveIndex = 0;

    public int currentWave = 1;

    public Wave[] wavesArray;

    private GameObject[] enemiesThisWave;

    private int currentEnemyIndex = 0;

    public UnityEvent wavesEnded;

    public EnemyTracker enemyTracker;

    void Start()
    {
        PopulateWave();
    }

    // Update is called once per frame
    void Update()
    {

        if (waveActive)
        {
            deltaTracker += Time.deltaTime;
        }
        else
        {
            deltaTracker = 0.0f;
            numInstancedEnemies = 0;
            currentEnemyIndex = 0;
        }

        if (deltaTracker >= spawnInterval && numInstancedEnemies < numEnemiesToSpawn)
        {
            numInstancedEnemies += 1;

            enemyTracker.SpawnEnemy(enemiesThisWave[currentEnemyIndex], splinePath, currentcamera, core);

            currentEnemyIndex += 1;
            deltaTracker = 0.0f;

            if (currentEnemyIndex == numEnemiesToSpawn)
            {
                StopWave();
                currentWaveIndex += 1;
                if (currentWaveIndex < wavesArray.Length)
                {
                    PopulateWave();
                }
            }
        }
        else if (numInstancedEnemies >= numEnemiesToSpawn)
        {
            StopWave();
        }
    }


    private void PopulateWave()
    {

        enemiesThisWave = wavesArray[currentWaveIndex].enemiesInWave;

        numEnemiesToSpawn = enemiesThisWave.Length;
    }

    public void StartWave()
    {
        print("Starting wave");
        if(!enemyTracker.CheckIfEnemiesExist())
        {
            waveActive = true;
        }
        
    }
    public void StopWave()
    {
        waveActive = false;
    }

}
