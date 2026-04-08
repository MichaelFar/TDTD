using UnityEngine;
using System.Collections;
using System.Linq;
public class TowerLookAtEnemyConstantAction : BaseTowerConstantAction
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private BaseEnemy focusedEnemy;

    public GameObject objectToRotate;

    public float sphereCastRadius = 5.0f;

    public float rotationSpeed = 5.0f;

    public bool shouldSetTarget = false;

    //public GameObject target;

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
        
        //focusedEnemyPresent = false;
        
        Collider[] collider_array = Physics.OverlapSphere(transform.position, sphereCastRadius);
        
        foreach (Collider i in collider_array)
        {
            
            bool is_enemy = i.GetComponent<BaseEnemy>();
            BaseEnemy enemy_instance;
            
            if (focusedEnemy == null)
            {
                if (is_enemy)
                {
                    shouldExecuteEvent = true;
                    Now_Able_To_Execute.Invoke();
                    print("Enemy detected");
                    enemy_instance = i.GetComponent<BaseEnemy>();
                    focusedEnemy = enemy_instance;
                    if(shouldSetTarget)
                    {
                        target = focusedEnemy.gameObject;
                    }
                }
            }
            
        }
        //Check if the focused enemy is currently within range
        if(focusedEnemy)
        {
            if(Vector3.Distance(focusedEnemy.transform.position, transform.position) > sphereCastRadius)
            {
                print("Setting should execute to false");
                focusedEnemy = null;
                target = null;
                shouldExecuteEvent = false;
                Now_Able_To_Execute.Invoke();
            }
        }
        else
        {
            print("Setting should execute to false");
            target = null;
            shouldExecuteEvent = false;
            Now_Able_To_Execute.Invoke();
        }

    }
}
