using UnityEngine;
using System.Collections;
public class TowerLookAtEnemyConstantAction : BaseTowerConstantAction
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private BaseEnemy focusedEnemy;

    public GameObject objectToRotate;

    public float sphereCastRadius = 5.0f;

    public float rotationSpeed = 5.0f; 

    void Start()
    {

        InvokeRepeating("CheckForEnemiesInShape", 0.0f, 0.1f);
        //StartCoroutine(CheckForEnemiesInShape());
    }

    // Update is called once per frame
    
    public override void ExecuteAction(float delta)
    {
        if(focusedEnemy != null)
        {
            Quaternion target_rotation = Quaternion.LookRotation(transform.position - focusedEnemy.transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, target_rotation, rotationSpeed * delta);
        }
            
    }

    private void OnTriggerStay(Collider other)
    {
        /*
        bool is_enemy = other.GetComponent<BaseEnemy>();
        print("Something entered");
        if(is_enemy)
        {
            
            BaseEnemy enemy_instance = other.GetComponent<BaseEnemy>();

            focusedEnemy = enemy_instance;
        }
        */
    }

    public void CheckForEnemiesInShape()
    {
        print("Checking for enemies");
        if(focusedEnemy == null)
        {
            
            foreach( Collider i in Physics.OverlapSphere(transform.position, sphereCastRadius))
            {
                bool is_enemy = i.GetComponent<BaseEnemy>();

                if (is_enemy)
                {
                    print("Enemy detected");
                    BaseEnemy enemy_instance = i.GetComponent<BaseEnemy>();
                    focusedEnemy = enemy_instance;
                }
            }
            
        }
        
        
    }
}
