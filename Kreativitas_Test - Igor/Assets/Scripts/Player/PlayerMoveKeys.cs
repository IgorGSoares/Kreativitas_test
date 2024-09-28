using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeys : MonoBehaviour
{
    [SerializeField] float speedMove = 0.5f;
    [SerializeField] Rigidbody2D rb;

    private float hMove;

    void Update()
    {
        float hMove = Input.GetAxisRaw("Horizontal") * speedMove;
        //Debug.Log(hMove);

        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            Debug.Log("pressing");
        }

        transform.position += transform.right * hMove * Time.deltaTime;

        //rb.velocity = new Vector2(speedMove * Time.deltaTime, rb.velocity.y);
    }

    private void FixedUpdate() {
        // rb.velocity = new Vector2(hMove, rb.velocity.y);
        // Debug.Log(rb.velocity);

        //rb.AddForce(transform.forward * hMove, ForceMode2D.Force);
    }
}
