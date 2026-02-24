using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Splines;
using System.Collections.Generic;
public class EnemyTracker : MonoBehaviour
{

    private List<GameObject> instancedEnemies = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEnemy(GameObject enemy_to_spawn, SplineContainer spline_path, Camera current_camera, CoreHandler core)
    {
        GameObject enemy_instance = Instantiate(enemy_to_spawn, transform.position, Quaternion.identity);
        print("Enemy instance is " + enemy_instance);
        BaseEnemy base_enemy_instance = enemy_instance.GetComponent<BaseEnemy>();
        enemy_instance.GetComponent<SplineAnimate>().Container = spline_path;
        //enemy_instance.GetComponent<BillBoardUI>().currentCamera = currentcamera;
        base_enemy_instance.billBoardUI.currentCamera = current_camera;
        base_enemy_instance.Reached_End_Of_Path += core.TakeDamage;
        base_enemy_instance.StartMoving();
        instancedEnemies.Add(enemy_instance);
    }

    public bool CheckIfEnemiesExist()
    {
        bool has_living_enemies = false;
        print("Checking if enemies exist");
        foreach(GameObject i in instancedEnemies)
        {
            if(i)
            {
                has_living_enemies = true;
            }
        }
        print("No enemies found");
        return has_living_enemies;
    }
}
