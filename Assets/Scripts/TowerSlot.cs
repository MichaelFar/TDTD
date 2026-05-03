using UnityEngine;
using UnityEngine.InputSystem.HID;

public class TowerSlot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool isOccupied = false;

    private GameObject currentTower;

    //public bool hasDemolishObstacle = false;
    private bool _hasDemolishObstacle; // field

    public bool hasDemolishObstacle   // property
    {
        get { 
                return _hasDemolishObstacle; 
            }  // get method
        set {
                
                _hasDemolishObstacle = value; 
                if(value)
                {
                    InstanceDemolishObstacle();
                }
            }  // set method
    }

    public bool instanceWithDemolishObstacle = false;

    public GameObject demolishObstaclePrefab;
    public GameObject demolishObstacleInstance;
    void Start()
    {
        if(instanceWithDemolishObstacle)
        {
            hasDemolishObstacle = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstanceNewTower(GameObject new_tower_object)
    {
        if(!isOccupied)
        {
            
            currentTower = Instantiate(new_tower_object, transform.position, Quaternion.identity);
            isOccupied = true;
        }
            
    }
    public void DestroyTower()
    {
        Destroy(currentTower);
        isOccupied = false;
    }
    public void DestroyDemolishObstacle()
    {
        Destroy(demolishObstacleInstance);
        isOccupied = false;
    }
    public Tower GetTower()
    {
        return currentTower.GetComponent<Tower>();
    }
    private void InstanceDemolishObstacle()
    {
        demolishObstacleInstance = Instantiate(demolishObstaclePrefab, transform.position, Quaternion.identity);
        isOccupied = true;
    }

}
