using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] Pooling pooling;

    void OnEnable()
    {
        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }

    void Update()
    {
        // Debug.Log(Camera.main.WorldToViewportPoint(transform.position));

        if(Camera.main.WorldToViewportPoint(transform.position).y > 1)
        {
            gameObject.SetActive(false);
            pooling.Enqueue(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Block")
        {
            //gameObject.SetActive(false);
            pooling.Enqueue(gameObject);
        }
    }

    public void SetPooling(Pooling pooling) => this.pooling = pooling;
}
