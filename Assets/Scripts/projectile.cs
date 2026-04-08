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

    void Start()
    {
        print("Instancing projectile");
        //transform.rotation = rotationContainer.transform.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        direction_to_travel = -transform.forward;
        
        if(target)
        {
            deltaCounter += Time.deltaTime;
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
            }
                
            Destroy(gameObject);
        }
        else if(other.tag == "DestroysProjectiles")
        {
            Destroy(gameObject);
        }
    }
    
}
