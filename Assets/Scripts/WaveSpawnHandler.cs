using UnityEngine;
<<<<<<< HEAD
=======
using UnityEngine.Events;
>>>>>>> main
using UnityEngine.Splines;

public class WaveSpawnHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CoreHandler core;

<<<<<<< HEAD
    public GameObject debugBaseEnemyToSpawn;

=======
>>>>>>> main
    public SplineContainer splinePath;

    public Camera currentcamera;

    private bool waveActive = false;

<<<<<<< HEAD
    public int numEnemiesToSpawn = 15;

    private int numInstancedEnemies = 0;

    public float spawnInterval = 3.0f;

    private float deltaTracker = 0.0f;

    void Start()
    {
        
=======
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
>>>>>>> main
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        
        if(waveActive)
=======

        if (waveActive)
>>>>>>> main
        {
            deltaTracker += Time.deltaTime;
        }
        else
        {
            deltaTracker = 0.0f;
            numInstancedEnemies = 0;
<<<<<<< HEAD
=======
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
>>>>>>> main
        }

        if (deltaTracker >= spawnInterval && numInstancedEnemies < numEnemiesToSpawn)
        {
            numInstancedEnemies += 1;
<<<<<<< HEAD
            SpawnEnemy();
            deltaTracker = 0.0f;
        }
        else if(numInstancedEnemies >= numEnemiesToSpawn)
=======

            enemyTracker.SpawnEnemy(enemiesThisWave[currentEnemyIndex], splinePath, currentcamera, core);
            UpdateSpawnInterval();
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
>>>>>>> main
        {
            StopWave();
        }
    }

<<<<<<< HEAD
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
=======

    private void PopulateWave()
    {

        enemiesThisWave = wavesArray[currentWaveIndex].enemiesInWave;

        

        numEnemiesToSpawn = enemiesThisWave.Length;
>>>>>>> main
    }

    public void StartWave()
    {
<<<<<<< HEAD
        waveActive = true;
    }
    public void StopWave()
    {
        waveActive = false;
    }
=======
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
    private void UpdateSpawnInterval()
    {
        spawnInterval = wavesArray[currentWaveIndex].intervalForThisEnemy.Length - 1 > currentEnemyIndex ? wavesArray[currentWaveIndex].intervalForThisEnemy[currentEnemyIndex] : wavesArray[currentWaveIndex].defaultSpawnInterval;
    }
    public void StopWave()
    {
        
        waveActive = false;
    }

>>>>>>> main
}
