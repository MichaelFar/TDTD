using UnityEngine;

public class HealEnemiesInRange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float sphereCastRadius = 10.0f;
    public float healAmount = 2.0f;
    public float healInterval = 4.0f;
    private float deltaTracker = 0.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        deltaTracker += Time.deltaTime;
        if(deltaTracker >= healInterval)
        {
            deltaTracker = 0.0f;
            HealEnemiesInShape();
        }
    }
    void HealEnemiesInShape()
    {
        Collider[] collider_array = Physics.OverlapSphere(transform.position, sphereCastRadius);

        foreach (Collider i in collider_array)
        {
            if(i.GetComponent<BaseEnemy>())
            {
                i.GetComponent<HealthHandler>().HealForIncoming(healAmount);
            }
        }
    }
}
