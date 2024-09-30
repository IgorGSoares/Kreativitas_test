using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speedMove = 0.5f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Joystick Joystick;

    private float hMove;

    void Update()
    {
        // float hMove = Input.GetAxisRaw("Horizontal") * speedMove;
        // transform.position += transform.right * hMove * Time.deltaTime;

        var j = Joystick.Horizontal > 0 ? 1 : Joystick.Horizontal < 0 && Joystick.Horizontal > -1 ? -1 : 0;
        var dir = j * speedMove;
        transform.position += transform.right * dir * Time.deltaTime;
    }
}
