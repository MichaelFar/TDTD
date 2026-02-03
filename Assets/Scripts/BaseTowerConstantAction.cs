using UnityEngine;

public class BaseTowerConstantAction : BaseTowerAction
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public override void ExecuteAction()
    {
        print("Executing constant action");
    }
}
