using UnityEngine;

public class RandomEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] randomEnemyPool;
    [HideInInspector] public GameObject chosenRandomEnemy;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject ChooseRandomEnemyAndDestroySelf()
    {
        chosenRandomEnemy = randomEnemyPool[Random.Range(0, randomEnemyPool.Length)];
        Destroy(gameObject);
        return chosenRandomEnemy;
    }
}
