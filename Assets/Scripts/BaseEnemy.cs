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
    
}
