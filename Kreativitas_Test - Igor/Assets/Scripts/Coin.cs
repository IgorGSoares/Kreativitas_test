using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Pooling pooling;

    void OnEnable()
    {
        var dir = Random.Range(0, 2);
        if(dir == 0) dir = -1;

        var force = Random.Range(1, 5);

        rb.AddForce(Vector2.left * dir * force, ForceMode2D.Impulse);
    }

    public void SetPooling(Pooling pooling) => this.pooling = pooling;

    void OnTrigerEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            pooling.Enqueue(gameObject);
        }
    }

}
