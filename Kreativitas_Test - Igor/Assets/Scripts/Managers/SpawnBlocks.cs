using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    [SerializeField] GameObject[] blocksPrefabs;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float delaySpawn;

    private bool gameBegin = false;

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
        while (gameBegin)
        {
            var s = Random.Range(0, spawnPoints.Length);
            var b = Random.Range(0, blocksPrefabs.Length);
            GameObject obj = Instantiate(blocksPrefabs[b], null);
            obj.transform.position = spawnPoints[s].position;

            var block = obj.GetComponent<Block>();
            block.SetDirection(spawnPoints[s]);

            Debug.Log(spawnPoints[s].gameObject.name);
            block.InitBlock();

            // if(Camera.main.WorldToViewportPoint(spawnPoints[s].position).x > 1)
            // {
                
            // }

            yield return new WaitForSeconds(delaySpawn);
        }
    }
}
