using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Pooling poolingBullets;
    [SerializeField] Transform spawnPoint;
    private bool playing = false;

    void OnEnable()
    {
        GlobalActions.OnGameBegins += StartShoot;
        GlobalActions.OnPlayerDies += StopShooting;
    }

    void OnDisable()
    {
        GlobalActions.OnGameBegins -= StartShoot;
        GlobalActions.OnPlayerDies -= StopShooting;
    }

    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.W) && !playing)
    //     {
    //         playing = !playing;
    //         StartCoroutine(StartShooting());
    //     }
    //     // else if(Input.GetKeyDown(KeyCode.W) && playing)
    //     // {
    //     //     playing = !playing;
    //     //     //StartCoroutine(StartShooting());
    //     // }
    // }

    private void StartShoot()
    {
        playing = !playing;
        StartCoroutine(StartShooting());
    }

    private void StopShooting()
    {
        playing = !playing;
        StopCoroutine(StartShooting());
    }

    IEnumerator StartShooting()
    {
        //Debug.Log("shoot");

        var fireRate = GameManager.Instance.FireRate;
        while(playing)
        {
            poolingBullets.SpawnOne(spawnPoint);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
