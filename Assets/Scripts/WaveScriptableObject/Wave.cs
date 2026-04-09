using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Waves/Wave")]
public class Wave : ScriptableObject
{
    
    public GameObject[] enemiesInWave;

    
    
    public float[] intervalForThisEnemy;
    public float defaultSpawnInterval = 3.0f;
}
