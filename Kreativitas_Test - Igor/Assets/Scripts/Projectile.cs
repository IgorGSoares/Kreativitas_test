using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;

    void OnEnable()
    {
        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }

    void Update()
    {
        // Debug.Log(Camera.main.WorldToViewportPoint(transform.position));

        if(Camera.main.WorldToViewportPoint(transform.position).y > 1) gameObject.SetActive(false);
    }
}
