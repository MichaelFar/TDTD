using UnityEngine;

public class Tower : MonoBehaviour
{
    public float actionInterval = 1.0f;

    private float timerFloat = 0.0f;

    public GameObject head;

    private BaseTowerAction towerActionObject;

    private BaseTowerConstantAction towerConstantActionObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        towerActionObject = GetComponent<BaseTowerAction>();
        towerConstantActionObject = GetComponent<BaseTowerConstantAction>();
    }

    // Update is called once per frame
    void Update()
    {
        timerFloat += Time.deltaTime;

        TowerConstantBehavior(Time.deltaTime);

        if (timerFloat >= actionInterval)
        {
            timerFloat = 0.0f;
            TowerAction();
        }
    }

    private void TowerAction()
    {
        if(towerActionObject != null)
        {
            towerActionObject.ExecuteAction();
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
}
