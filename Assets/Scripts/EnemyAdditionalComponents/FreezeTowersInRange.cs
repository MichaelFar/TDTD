using UnityEngine;

public class FreezeTowersInRange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float sphereCastRadius = 10.0f;
    public float freezeDuration = 3.0f;
    public float freezeInterval = 4.0f;
    private float deltaTracker = 0.0f;
    public GameObject freezeSphere;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        deltaTracker += Time.deltaTime;
        if (deltaTracker >= freezeInterval)
        {
            deltaTracker = 0.0f;
            FreezeTowersInShape();
        }
    }
    void FreezeTowersInShape()
    {
        Collider[] collider_array = Physics.OverlapSphere(transform.position, sphereCastRadius);

        foreach (Collider i in collider_array)
        {
            Tower this_tower = i.gameObject.GetComponentInParent<Tower>();
            if (this_tower != null)
            {
                print("Freezing tower");
                this_tower.SetFreezeDuration(freezeDuration);
                this_tower.freezeAllActions = true;
                GameObject spawned_freeze_sphere = Instantiate(freezeSphere, this_tower.transform);
                spawned_freeze_sphere.GetComponent<FreezeSphere>().duration = freezeDuration;
            }
        }
    }

    
}
