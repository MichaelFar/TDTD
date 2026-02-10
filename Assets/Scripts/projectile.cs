using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 800.0f;

    public float damagePower = 1.0f;

    public Rigidbody rb;


    void Start()
    {
        print("Instancing projectile");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = speed * -transform.forward * Time.deltaTime; 
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Projectile hit: " + other);
        if(other.GetComponent<BaseEnemy>())
        {
            other.GetComponent<HealthHandler>().TakeDamage(damagePower);
            Destroy(gameObject);
        }
    }
}
