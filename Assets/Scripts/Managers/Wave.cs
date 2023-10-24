using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Wave", order = 51)]
public class Wave : ScriptableObject
{
    public int enemyCount; 
    public float enemySpeed;
    public float enemyHealth; 
}
