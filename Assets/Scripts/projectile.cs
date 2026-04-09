//using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 800.0f;

    public float damagePower = 1.0f;

    public Rigidbody rb;

    public GameObject target;
    //How long the projectile will home to the target if it exists
    public float timeToHome = 0.2f;
    //public GameObject rotationContainer;
    Vector3 direction_to_travel;
    private float deltaCounter = 0.0f;

    //How many enemies can this pierce before getting destroyed
    public int pierceCount = 0;

    private float lifetime = 20.0f;

    public int bounceCount = 0;
    void Start()
    {
        print("Instancing projectile");
        //transform.rotation = rotationContainer.transform.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        deltaCounter += Time.deltaTime;
        if(deltaCounter >= lifetime)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        direction_to_travel = -transform.forward;
        
        if(target)
        {
            
            if (deltaCounter <= timeToHome)
            {
                direction_to_travel = target.transform.position - transform.position;
                direction_to_travel.Normalize();
            }
            else
            {
                deltaCounter = 0.0f;
            }

        }
        rb.linearVelocity = speed * direction_to_travel * Time.deltaTime; 
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Projectile hit: " + other);
        if(other.GetComponent<HealthHandler>())
        {
            if(other.GetComponent<BaseEnemy>())
            {
                other.GetComponent<HealthHandler>().TakeDamage(damagePower);
                if (pierceCount <= 0 && bounceCount <= 0)
                {
                    
                    Destroy(gameObject);
                }
                if(pierceCount > 0)
                {
                    print("Piercing enemy");
                    pierceCount -= 1;
                }
                if(bounceCount > 0)
                {
                    print("Bouncing on enemy");
                    bounceCount -= 1;
                    float random_rotation_degree_left = Random.Range(-70.0f, -35.0f);
                    float random_rotation_degree_right = Random.Range(35.0f, 70.0f);

                    float random_rotation_degree = Random.Range(0, 2) == 0 ? random_rotation_degree_left : random_rotation_degree_right;
                    transform.rotation = transform.rotation * Quaternion.Euler(Vector3.up * random_rotation_degree);
                }
            }
            
                
        }
        else if(other.tag == "DestroysProjectiles")
        {
            Destroy(gameObject);
        }
    }
    

}
