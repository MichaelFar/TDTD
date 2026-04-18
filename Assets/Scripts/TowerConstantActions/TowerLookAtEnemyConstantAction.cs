using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using System.Collections.Generic;
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
        //InvokeRepeating("CheckForEnemyLOS", 0.0f, 0.1f);
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
                    enemy_instance = i.GetComponent<BaseEnemy>();
                    focusedEnemy = enemy_instance;
                    if(CheckForEnemyInLOS(focusedEnemy))
                    {
                        shouldExecuteEvent = true;
                        Now_Able_To_Execute.Invoke();
                        if (shouldSetTarget)
                        {
                            target = focusedEnemy.gameObject;
                        }
                    }
                    else
                    {
                        print("Enemy found but blocked");
                        focusedEnemy = null;
                        shouldExecuteEvent = false;
                        Now_Able_To_Execute.Invoke();
                        
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
            
            if(!CheckForEnemyInLOS(focusedEnemy))
            {
                
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
    public bool CheckForEnemyInLOS(BaseEnemy enemy_to_check)
    {
        if(!enemy_to_check)
        {
            return false;
        }
        Vector3 point = enemy_to_check.gameObject.transform.position;
        Vector3 dir = (transform.position - point).normalized * -1.0f;
        // Ray r = new Ray(transform.position, dir);
        Ray ray_vector = new Ray(transform.position, dir);

        RaycastHit[] ray_hits = Physics.RaycastAll(ray_vector, sphereCastRadius);
        //RaycastHit hit;
        //bool should_ignore_wall = false;
        List<GameObject> ordered_object_list = new List<GameObject>();// = new GameObject[ray_hits.Length];
        foreach (RaycastHit i in ray_hits)
        {
            ordered_object_list.Add(i.collider.gameObject);
            //print("Ordered list is " + ordered_object_list);
            //print(i.collider.gameObject + " object found");
            /*
            if (i.collider.GetComponent<BaseEnemy>() == focusedEnemy)
            {
                print("Should ignore wall is true");
                should_ignore_wall = true;
            }
            if (i.collider.tag == "DestroysProjectiles" && !should_ignore_wall)
            {
                print("Found wall that blocks vision");
                //return false;
            }
            */
        }
        //Action action = 
        
        ordered_object_list = ordered_object_list.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();

        foreach (GameObject i in ordered_object_list)
        {
            print(i.gameObject + " object found");
            if(i.CompareTag("DestroysProjectiles"))
            {
                return false;
            }
            if(i.GetComponent<BaseEnemy>() == enemy_to_check)
            {
                return true;
            }
        }
        print("Object list is " + ordered_object_list);
        return true;
    }
        
}
