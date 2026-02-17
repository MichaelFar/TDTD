using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

public class WaveSpawnHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CoreHandler core;

    public SplineContainer splinePath;

    public Camera currentcamera;

    private bool waveActive = false;

    private int numEnemiesToSpawn = 15;

    private int numInstancedEnemies = 0;

    private float spawnInterval = 3.0f;


    public float defaultSpawnInterval = 2.0f;
    private float deltaTracker = 0.0f;

    private int currentWaveIndex = 0;

    private int currentWave = 1;

    public Wave[] wavesArray;

    private GameObject[] enemiesThisWave;

    private int currentEnemyIndex = 0;

    public UnityEvent wavesEnded;

    public EnemyTracker enemyTracker;

    public WaveText waveText;

    private bool allWavesCompleted = false;
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
            if(!enemyTracker.CheckIfEnemiesExist() && currentWaveIndex != 0 && !allWavesCompleted)
            {
                waveText.IndicateWaveCompleted();
                if(currentWaveIndex == wavesArray.Length)
                {
                    allWavesCompleted = true;
                    //print("completed all waves");
                    wavesEnded.Invoke();
                }
            }
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

        spawnInterval = wavesArray[currentWaveIndex].intervalForThisEnemy.Length > currentEnemyIndex ? wavesArray[currentWaveIndex].intervalForThisEnemy[currentEnemyIndex] : wavesArray[currentWaveIndex].defaultSpawnInterval;

        numEnemiesToSpawn = enemiesThisWave.Length;
    }

    public void StartWave()
    {
        print("Starting wave");
        if(!enemyTracker.CheckIfEnemiesExist() && currentWaveIndex < wavesArray.Length && !waveActive)
        {
            waveText.SetCurrentWave(currentWave);
            currentWave += 1;
            
            waveActive = true;
        }

        if (currentWaveIndex == wavesArray.Length - 1)
        {
            waveText.IndicateFinalWave();
        }


    }
    public void StopWave()
    {
        
        waveActive = false;
    }

}
