using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsPosition : MonoBehaviour
{
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;
    [SerializeField] GameObject upWall;
    void Start()//REMINDME: incluir no manager e chamar no inicio de jogo
    {
        //Debug.Log(Camera.main.WorldToViewportPoint(rightWall.transform.position));
        var r = Camera.main.ViewportToWorldPoint(new Vector3(1.05f, 0.63f, 0));
        var l = Camera.main.ViewportToWorldPoint(new Vector3(-0.05f, 0.63f, 0));
        var u = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.05f, 0));

        rightWall.transform.position = r;
        leftWall.transform.position = l;
        upWall.transform.position = u;
    }
}
