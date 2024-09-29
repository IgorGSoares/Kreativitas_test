using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockSplit : Block
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] Block[] blocks;

    protected override void SpawnLoot()
    {
        //throw new System.NotImplementedException();
    }

    protected override void SpawnParts()
    {
        //throw new System.NotImplementedException();
        if(blocks.Length == 0 || blocks == null) return;

        if(MaxLife % 2 != 0)
        {
            blocks[0].MaxLife = MaxLife / 2;
            blocks[1].MaxLife = MaxLife - MaxLife / 2;
        }

        foreach (var block in blocks)
        {
            block.transform.parent = null;
            block.transform.position = spawnPoint.position;
            // var dir = Random.Range(0, 2);
            // if (dir == 0) dir = -1;

            if (MaxLife % 2 == 0) block.MaxLife = MaxLife / 2;

            block.gameObject.SetActive(true);
            block.InitBlock();
        }

        blocks[0].RB.AddForce( new Vector2(-1, 1) * 3.5f, ForceMode2D.Impulse);
        blocks[1].RB.AddForce( new Vector2(1, 1) * 3.5f, ForceMode2D.Impulse);
    }
}
