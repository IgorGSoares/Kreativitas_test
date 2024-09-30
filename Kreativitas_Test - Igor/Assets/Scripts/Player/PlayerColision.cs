using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    [SerializeField] GameObject player;
    //[SerializeField] Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Block") //REMINDME: action onplayerdies
        {
            player.SetActive(false);
            //Debug.Log("enter");
            GlobalActions.OnPlayerDies?.Invoke();

            GameManager.Instance.PauseGame();
            GameManager.Instance.GameOver();
            GameManager.Instance.CanvasManager.GameOver();
        }
        //if(other.gameObject.tag == "Coin") rb.velocity = Vector3.zero;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall") Debug.Log("wall");
    }
}
