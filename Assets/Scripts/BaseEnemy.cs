using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public HealthHandler healthHandler;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        BehaviorOnDestroy();
    }
    private void BehaviorOnDestroy()
    {
        print("BaseEnemyDestroyed");
    }
}
