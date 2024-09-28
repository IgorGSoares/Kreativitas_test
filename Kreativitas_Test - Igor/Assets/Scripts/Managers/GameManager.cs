using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    #region VARIABLES
    [SerializeField] float fireRate;
    [SerializeField] int damage;
    [SerializeField] int pool;

    #endregion

    #region RETURN VALUES
    public float GetFireRate() => fireRate;
    public int GetDamage() => damage;
    public int GetPool() => pool;

    #endregion
}
