using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
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


    #region CLASSES
    [SerializeField] Pooling poolingCoins;
    #endregion



    #region RETURN VALUES
    public float GetFireRate() => fireRate;
    public int GetDamage() => damage;
    public int GetPool() => pool;

    public Pooling PoolingCoins => poolingCoins;
    
    #endregion

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
