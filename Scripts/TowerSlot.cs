using UnityEngine;
using UnityEngine.InputSystem.HID;

public class TowerSlot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    bool isOccupied = false;

    GameObject currentTower;
    void Start()
    {
        
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
}
