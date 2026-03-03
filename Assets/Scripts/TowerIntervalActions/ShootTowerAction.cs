using UnityEngine;

public class ShootTowerAction : BaseTowerAction
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject projectileToShoot;
    public GameObject objectToShootFrom;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ExecuteAction(float delta_time = 0.0f)
    {
        Executed_Action.Invoke();
        print("Spawning projectile");
        // GameObject projectile_instance = Instantiate(projectileToShoot);
        Instantiate(projectileToShoot, objectToShootFrom.transform.position, transform.rotation);
    }
}
