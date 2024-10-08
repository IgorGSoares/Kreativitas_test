using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Block : MonoBehaviour
{
    [SerializeField] int maxLife;
    [SerializeField] TextMeshProUGUI lifeCount;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] protected float gravityScale;

    [SerializeField] Vector3 initialDirection = Vector3.zero;
    [SerializeField] CircleCollider2D circleCollider2D;

    protected int currentLife;
    private bool isColiding = false;
    public float limit;

    public int MaxLife { get { return maxLife; } set { maxLife = value; } }
    public Rigidbody2D RB => rb;
    public CircleCollider2D CircleCollider2D => circleCollider2D;
    


    void OnEnable()
    {
        GlobalActions.OnPlayerDies += StopPhysics;
    }

    void OnDisable()
    {
        GlobalActions.OnPlayerDies -= StopPhysics;
    }

    public void SetCurrLife()
    {
        currentLife = maxLife;
        lifeCount.text = currentLife.ToString();
    }


    public void InitBlock()
    {
        circleCollider2D.enabled = false;

        currentLife = maxLife;
        lifeCount.text = currentLife.ToString();

        //Physics2D.IgnoreLayerCollision(6, 8);
        rb.AddForce(initialDirection * 2f, ForceMode2D.Impulse);
        //Debug.Log(rb.velocity);
    }

    // public void DropBlock()
    // {
    //     currentLife = maxLife;
    //     lifeCount.text = currentLife.ToString();

    //     // var dir = Random.Range(0, 2);
    //     // if(dir == 0) dir = -1;
    //     // var force = Random.Range(1, 3);

    //     rb.gravityScale = gravityScale;
    //     circleCollider2D.enabled = true;

    //     //rb.AddForce(Vector2.left * dir * force, ForceMode2D.Impulse);
    // }

    void Update()
    {
        if (currentLife <= 0)
        {
            SpawnLoot();
            SpawnParts();
            gameObject.SetActive(false);
        }

        if(initialDirection != Vector3.zero)
        {
            if ((limit == 0.15f && Camera.main.WorldToViewportPoint(transform.position).x >= limit)
            || (limit == 0.85f && Camera.main.WorldToViewportPoint(transform.position).x <= limit))
            {
                rb.gravityScale = gravityScale;
                //Debug.Log("enter if");
                //Physics2D.IgnoreLayerCollision(6, 8, false);
                circleCollider2D.enabled = true;
            }
        }
    }

    protected abstract void SpawnLoot();
    protected abstract void SpawnParts();


    protected void StopPhysics()
    {
        rb.velocity = Vector3.zero;
        rb.gravityScale = 0;
    }

    public void SetDirection(Transform t)
    {
        var p = Camera.main.WorldToViewportPoint(t.position);
        //Debug.Log(p);
        if(p.x < 0)
        {
            initialDirection = Vector3.left * -1;
            limit = 0.15f;
        }
        else if(p.x > 1)
        {
            initialDirection = Vector3.left;
            limit = 0.85f;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(isColiding) return;

        if(other.gameObject.tag == "Bullet")
        {
            isColiding = true;
            currentLife -= GameManager.Instance.Damage;
            other.gameObject.SetActive(false);
            //Debug.Log(currentLife);
            lifeCount.text = currentLife.ToString();
            StartCoroutine(ResetColision());
        }
    }

    IEnumerator ResetColision()
    {
        yield return new WaitForEndOfFrame();
        isColiding = false;
    }
}
