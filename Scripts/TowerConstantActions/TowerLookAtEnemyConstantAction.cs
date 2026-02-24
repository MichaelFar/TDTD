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
        Executed_Action.Invoke();
        if (focusedEnemy != null)
        {
            Quaternion target_rotation = Quaternion.LookRotation(transform.position - focusedEnemy.transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, target_rotation, rotationSpeed * delta);
        }
        else
        {
            Quaternion target_rotation = Quaternion.LookRotation(transform.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, target_rotation, rotationSpeed * delta);
        }
            
    }

    public void CheckForEnemiesInShape()
    {
        print("Checking for enemies");

        bool enemy_exists_in_range = false;
        foreach( Collider i in Physics.OverlapSphere(transform.position, sphereCastRadius))
        {
            bool is_enemy = i.GetComponent<BaseEnemy>();
            if (enemy_exists_in_range == false)
            {
                enemy_exists_in_range = is_enemy;
            }
            if (focusedEnemy == null)
            {
                if (is_enemy)
                {
                    shouldExecuteEvent = true;
                    Now_Able_To_Execute.Invoke();
                    print("Enemy detected");
                    BaseEnemy enemy_instance = i.GetComponent<BaseEnemy>();
                    focusedEnemy = enemy_instance;
                }
            }
        }
        if(!enemy_exists_in_range)
        {
            print("Setting should execute to false");
            focusedEnemy = null;
            shouldExecuteEvent = false;
            Now_Able_To_Execute.Invoke();
        }
            
        
        
        
    }
}
