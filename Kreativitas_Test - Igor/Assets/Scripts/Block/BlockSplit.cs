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
            // block.transform.localScale -= Vector3.one;
            // Debug.Log(block.transform.localScale);
            if(transform.localScale == Vector3.one * 3)
            {
                block.transform.localScale = Vector3.one * 2;
            }
            else if(transform.localScale == Vector3.one * 2)
            {
                block.transform.localScale = Vector3.one * 1;
                // Debug.Log(block.transform.localScale);
            }

            // var dir = Random.Range(0, 2);
            // if (dir == 0) dir = -1;

            if (MaxLife % 2 == 0) block.MaxLife = MaxLife / 2;

            block.gameObject.SetActive(true);
            //block.DropBlock();

            block.SetCurrLife();
            block.RB.gravityScale = gravityScale;
            block.CircleCollider2D.enabled = true;
        }

        blocks[0].RB.AddForce( new Vector2(-1, 1) * 3.5f, ForceMode2D.Impulse);
        blocks[1].RB.AddForce( new Vector2(1, 1) * 3.5f, ForceMode2D.Impulse);
    }
}
