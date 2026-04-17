using UnityEngine;

public class FreezeSphere : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float duration = 0.0f;
    private float deltaCounter = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(duration > 0.0)
        {
            deltaCounter += Time.deltaTime;
            if(deltaCounter >= duration)
            {
                Destroy(gameObject);
            }
        }
    }
}
