using UnityEngine;

public class GearShootInterval : BaseTowerAction
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject projectileToShoot;
    //public GameObject objectToShootFrom;
    public int numProjectiles;

    private bool enemyInRange = false;

    public float sphereCastRadius = 5.0f;
    void Start()
    {
        shouldExecuteEvent = true;
        Now_Able_To_Execute.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ExecuteAction(float delta_time = 0.0f)
    {
        Executed_Action.Invoke();
        ShootInMultiDirection();
        
    }
    public void ShootInMultiDirection()
    {
        if (CheckForEnemiesInShape())
        {

            float rotation_increment = 360.0f / numProjectiles;

            float additional_rotation = rotation_increment / 2.0f;

            for (int i = 0; i < numProjectiles; i++)
            {
                Instantiate(projectileToShoot, transform.position, Quaternion.Euler((Vector3.up * rotation_increment * i)) * Quaternion.Euler((Vector3.up * additional_rotation)));
            }
        }
        
    }

    private bool CheckForEnemiesInShape()
    {
        print("Checking for enemies in gear shooter");

        //focusedEnemyPresent = false;

        Collider[] collider_array = Physics.OverlapSphere(transform.position, sphereCastRadius);

        foreach (Collider i in collider_array)
        {
            bool is_enemy = i.GetComponent<BaseEnemy>();
            
            if (is_enemy)
            {
                return is_enemy;
            }
        }
        return false;
    }
}

