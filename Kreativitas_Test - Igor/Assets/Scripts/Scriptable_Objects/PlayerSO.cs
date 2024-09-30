using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObjects/PlayerSO", order = 0)]
public class PlayerSO : ScriptableObject
{
    public float firerate;
    public int damage;
    public int pool;
    public int coins;
    public int currentWave;
}
