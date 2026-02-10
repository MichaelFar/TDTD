using UnityEngine;
using UnityEngine.Events;

public class BaseTowerAction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public UnityEvent Now_Able_To_Execute;
    public bool shouldExecuteEvent = false;
    void Start()
    {
        //Now_Able_To_Execute = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void ExecuteAction(float delta_time = 0.0f)
    {
        //print("Executing interval action");
    }
}
