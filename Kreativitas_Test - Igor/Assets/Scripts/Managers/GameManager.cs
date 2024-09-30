using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

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
    [SerializeField] int currentWave;
    [SerializeField] GameObject cam;

    private int waveProgress;
    #endregion




    #region CLASSES
    [Space]
    [SerializeField] PlayerSO playerSO;
    [SerializeField] Pooling poolingCoins;
    [SerializeField] CanvasManager canvasManager;
    //[SerializeField] SpawnBlocks spawnBlocks;
    [SerializeField] WaveManager waveManager;
    #endregion




    #region RETURN VALUES
    public float FireRate { get { return fireRate; } set { fireRate = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public int Pool { get { return pool; } set { pool = value; } }
    public int Coins { get { return coins; } set { coins = value; } }
    public int CurrentWave => currentWave;

    public Pooling PoolingCoins => poolingCoins;
    public CanvasManager CanvasManager => canvasManager;
    //public SpawnBlocks SpawnBlocks => spawnBlocks;
    #endregion


    private void Start() {
        fireRate = playerSO.firerate;
        damage = playerSO.damage;
        coins = playerSO.coins;
        pool = playerSO.pool;
        currentWave = playerSO.currentWave;
    }

    public void StartGame()
    {
        var pos = new Vector3(0, 1.5f, cam.transform.position.z);
        //cam.transform.DOMoveY(1.5f, 0.15f).SetEase(Ease.OutQuint);
        cam.transform.position = pos;

        GlobalActions.OnGameBegins?.Invoke();
        waveManager.StartSpawn();
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

    public void GameOver()//NOTE: called in button
    {
        playerSO.coins = coins;
    }

    public void GameWin()
    {
        canvasManager.WinGame();
        playerSO.currentWave++;
        if(playerSO.currentWave >= waveManager.GetWavesArraySize()) playerSO.currentWave = 0;
        playerSO.coins = coins;
    }
}
