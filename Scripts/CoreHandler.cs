using UnityEngine;

public class CoreHandler : MonoBehaviour
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

    public void TakeDamage(float incoming_damage)
    {
        print("Taking damage");
        healthHandler.TakeDamage(incoming_damage);
    }
}
