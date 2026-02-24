using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Scriptable Objects/Wave")]
public class Wave : ScriptableObject
{
    public GameObject[] enemiesInWave;
    public float[] intervalForThisEnemy;
    public float defaultSpawnInterval = 3.0f;
}
