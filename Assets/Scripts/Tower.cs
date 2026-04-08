using UnityEngine;
using System.Collections;
public class Tower : MonoBehaviour
{
    public float actionInterval = 1.0f;

    private float timerFloat = 0.0f;

    public GameObject head;

    public float towerValue = 25.0f;

    public float refundRatio = 0.8f;
    public enum TOWERTYPE {GunTower, SupportTower};

    public TOWERTYPE towerType; //This will be how certain upgrades/perks/items will know which towers will be affected

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
    //Constant action will typically determine if the interval action should keep occuring
    public void CheckAndSetShouldContinueIntervalFromConstantAction()
    {
        print("Setting should execute event from constant action to " + towerConstantActionObject.shouldExecuteEvent);
        shouldContinueInterval = towerConstantActionObject.shouldExecuteEvent;
    }
    //There are potentially reasons that the interval action determines if it should be fired, for instance if ammo were to ever be a mechanic
    public void CheckAndSetShouldContinueIntervalFromIntervalAction()
    {
        print("Setting should execute event from interval action to " + towerIntervalActionObject.shouldExecuteEvent);
        shouldContinueInterval = towerIntervalActionObject.shouldExecuteEvent;
    }
    
}
