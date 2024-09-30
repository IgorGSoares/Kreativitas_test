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
    [SerializeField] int coins;
    #endregion




    #region CLASSES
    [Space]
    [SerializeField] PlayerSO playerSO;
    [SerializeField] Pooling poolingCoins;
    [SerializeField] CanvasManager canvasManager;
    [SerializeField] SpawnBlocks spawnBlocks;
    #endregion




    #region RETURN VALUES
    public float FireRate { get { return fireRate; } set { fireRate = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public int Pool { get { return pool; } set { pool = value; } }
    public int Coins { get { return coins; } set { coins = value; } }

    public Pooling PoolingCoins => poolingCoins;
    public CanvasManager CanvasManager => canvasManager;
    public SpawnBlocks SpawnBlocks => spawnBlocks;
    #endregion


    private void Start() {
        fireRate = playerSO.firerate;
        damage = playerSO.damage;
        coins = playerSO.coins;
        pool = playerSO.pool;
    }

    public void StartGame()
    {
        GlobalActions.OnGameBegins?.Invoke();
    }
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
        ResumeGame();
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        playerSO.coins = coins;
    }
}
