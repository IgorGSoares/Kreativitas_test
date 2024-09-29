using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSimple : Block
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] int qtdCoins = 3;

    protected override void SpawnLoot()
    {
        //throw new System.NotImplementedException();

        for (int i = 0; i < qtdCoins; i++)
        {
            GameManager.Instance.PoolingCoins.SpawnOne(spawnPoint);
        }
    }

    protected override void SpawnParts()
    {
        //throw new System.NotImplementedException();
    }
}
