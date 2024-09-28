using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Pooling poolingBullets;
    [SerializeField] Transform spawnPoint;
    private bool playing = false;

    void Update()
    {
        //REMINDME: transformar isto em uma action
        if(Input.GetKeyDown(KeyCode.W) && !playing)
        {
            playing = !playing;
            StartCoroutine(StartShooting());
        }
        // else if(Input.GetKeyDown(KeyCode.W) && playing)
        // {
        //     playing = !playing;
        //     //StartCoroutine(StartShooting());
        // }
    }

    IEnumerator StartShooting()
    {
        Debug.Log("shoot");

        var fireRate = GameManager.Instance.GetFireRate();
        while(playing)
        {
            poolingBullets.SpawnOne(spawnPoint);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
