using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] int currentWave;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float delaySpawn;

    [SerializeField] Waves[] waves;
    private bool gameBegin = false;
    private int waveProgress = 0;
    private int currentTotal = 0;

    void OnEnable()
    {
        GlobalActions.OnGameBegins += StartSpawn;
        GlobalActions.OnPlayerDies += StopSpawn;
    }

    void OnDisable()
    {
        GlobalActions.OnGameBegins -= StartSpawn;
        GlobalActions.OnPlayerDies -= StopSpawn;
    }

    
    private void Start() {
        currentWave = GameManager.Instance.CurrentWave;

        // foreach (var wave in waves)
        // {
        //     //wave.Init();
        //     wave.SetTotal();
        // }
    }

    private void StartSpawn()
    {
        gameBegin = !gameBegin;
        StartCoroutine(SpawnBlock());
    }
    private void StopSpawn()
    {
        gameBegin = !gameBegin;
        StopCoroutine(SpawnBlock());
    }

    IEnumerator SpawnBlock()
    {
        Waves wave = waves[currentWave];
        currentTotal = wave.total;

        Debug.Log("call coroutine");

        while (gameBegin && waveProgress < currentTotal)
        {
            var spawn = Random.Range(0, spawnPoints.Length);
            var index = Random.Range(0, wave.blocksInWave.Count);
            var prefab = wave.blocksInWave[index].prefab;

            var x = wave.blocksInWave[index].values.x;
            var y = wave.blocksInWave[index].values.y;
            int life = Random.Range((int)x, (int)y);

            wave.blocksInWave[index].RemoveBlock();
            if(wave.blocksInWave[index].qtd <= 0) wave.blocksInWave.RemoveAt(index);
            wave.total--;

            GameObject obj = Instantiate(prefab, null);
            obj.transform.position = spawnPoints[spawn].position;

            var block = obj.GetComponent<Block>();
            block.SetDirection(spawnPoints[spawn]);
            block.MaxLife = life;
            block.InitBlock();

            waveProgress++;

            Debug.Log("total is: " + wave.total);

            yield return new WaitForSeconds(delaySpawn);
        }
    }
}

[System.Serializable]
public struct Waves
{
    public List<BlocksInWave> blocksInWave;
    public int total;

    // public void Init()
    // {
    //     var list = blocksInWave;
    //     blocksInWave = new List<BlocksInWave>();
    //     blocksInWave = list;

    //     total = 0;
    // }

    // public void SetTotal()
    // {
    //     total = 0;

    //     foreach (var block in blocksInWave)
    //     {
    //         total += block.qtd;
    //     }
    // }
}

[System.Serializable]
public struct BlocksInWave
{
    public GameObject prefab;
    public int qtd;
    public Vector2 values;

    public void RemoveBlock() => qtd--;
}
