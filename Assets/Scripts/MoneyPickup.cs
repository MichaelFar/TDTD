using UnityEngine;
using UnityEngine.Events;

public class MoneyPickup : MonoBehaviour
{
    public float value = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public UnityEvent Now_Able_To_Execute;
    public bool shouldExecuteEvent = false;
    public UnityEvent Executed_Action;
    void Start()
    {
        //Now_Able_To_Execute = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
