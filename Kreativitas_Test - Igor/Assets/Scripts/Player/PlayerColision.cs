using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    [SerializeField] GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Block") //REMINDME: action onplayerdies
        {
            player.SetActive(false);
            //Debug.Log("enter");
            GlobalActions.OnPlayerDies?.Invoke();

            GameManager.Instance.PauseGame();
            GameManager.Instance.CanvasManager.GameOver();
        }
    }
}
