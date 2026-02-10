using UnityEngine;
using System.Collections;
public class Tower : MonoBehaviour
{
    public float actionInterval = 1.0f;

    private float timerFloat = 0.0f;

    public GameObject head;

    private BaseTowerAction towerIntervalActionObject;

    private BaseTowerConstantAction towerConstantActionObject;

    public bool shouldContinueInterval = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        towerIntervalActionObject = GetComponent<BaseTowerAction>();

        towerConstantActionObject = GetComponent<BaseTowerConstantAction>();
        //towerConstantActionObject.Now_Able_To_Execute.AddListener(CheckAndSetShouldContinueInterval);
        //StartCoroutine(EndOfFramePopulation());
    }

    // Update is called once per frame
    void Update()
    {
        timerFloat += Time.deltaTime;

        TowerConstantBehavior(Time.deltaTime);

        if (timerFloat >= actionInterval && shouldContinueInterval)
        {
            timerFloat = 0.0f;
            TowerIntervalAction();
        }
    }

    private void TowerIntervalAction()
    {
        if(towerIntervalActionObject != null)
        {
            towerIntervalActionObject.ExecuteAction();
        }
    }

    private void TowerConstantBehavior(float delta)
    {
        if (towerConstantActionObject != null)
        {

            print("Executing interval action");
            towerConstantActionObject.ExecuteAction(delta);

        }
    }
    public void CheckAndSetShouldContinueIntervalFromConstantAction()
    {
        print("Setting should execute event to " + towerConstantActionObject.shouldExecuteEvent);
        shouldContinueInterval = towerConstantActionObject.shouldExecuteEvent;
    }
    public void CheckAndSetShouldContinueIntervalFromIntervalAction()
    {
        print("Setting should execute event to " + towerIntervalActionObject.shouldExecuteEvent);
        shouldContinueInterval = towerIntervalActionObject.shouldExecuteEvent;
    }
    
}
