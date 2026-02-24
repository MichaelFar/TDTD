using UnityEngine;
using UnityEngine.Events;

public class BaseTowerAction : MonoBehaviour
{
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
    public virtual void ExecuteAction(float delta_time = 0.0f)
    {
        Executed_Action.Invoke();
        //print("Executing interval action");
    }
}
