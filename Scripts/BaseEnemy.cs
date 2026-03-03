using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

public class BaseEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public HealthHandler healthHandler;
    public SplineAnimate splineAnimate;

    public Camera mainCamera;

    public BillBoardUI billBoardUI;

    public Action<float> Reached_End_Of_Path;

    public float damagePowerToCore = 1.0f;

    public GameObject[] potentialDropsArray;

    public float chanceToDrop = 25.0f;
    void Start()
    {
        splineAnimate.Completed += BehaviorOnCompletedPath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyThisEnemy()
    {
        CheckThenCreateDrop();
        Destroy(gameObject);
    }

    public void BehaviorOnCompletedPath()
    {
        Reached_End_Of_Path.Invoke(damagePowerToCore);
        
        Destroy(gameObject);
    }

    public void StartMoving()
    {
        splineAnimate.Play();
    }
    
    private void CheckThenCreateDrop()
    {
        float roll = UnityEngine.Random.Range(1.0f, 100.0f);
        if(roll <= chanceToDrop)
        {
            int rand_index = UnityEngine.Random.Range(0, potentialDropsArray.Length);
            Instantiate(potentialDropsArray[rand_index], transform.position, Quaternion.identity);
        }
    }
}
