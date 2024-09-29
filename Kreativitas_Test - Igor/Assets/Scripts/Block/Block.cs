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
    [SerializeField] float gravityScale;
    [SerializeField] Vector3 initialDirection = Vector3.zero;

    private int currentLife;
    private bool isColiding = false;

    public int MaxLife { get { return maxLife; } set { maxLife = value; } }
    public Rigidbody2D RB => rb;
    public void SetCurrLife() => currentLife = maxLife;


    void Start()
    {
        currentLife = maxLife;
        lifeCount.text = currentLife.ToString();

        Physics2D.IgnoreLayerCollision(6, 8);
        rb.AddForce(initialDirection * 2f, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (currentLife <= 0)
        {
            SpawnLoot();
            SpawnParts();
            gameObject.SetActive(false);
        }

        if(Camera.main.WorldToViewportPoint(transform.position).x >= 0.15f)
        {
            rb.gravityScale = gravityScale;
            //Debug.Log("enter if");
            Physics2D.IgnoreLayerCollision(6, 8, false);
        }
    }

    protected abstract void SpawnLoot();
    protected abstract void SpawnParts();


    void OnTriggerEnter2D(Collider2D other)
    {
        if(isColiding) return;

        if(other.gameObject.tag == "Bullet")
        {
            isColiding = true;
            currentLife -= GameManager.Instance.GetDamage();
            other.gameObject.SetActive(false);
            //Debug.Log(currentLife);
            lifeCount.text = currentLife.ToString();
            StartCoroutine(ResetColision());
        }
    }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "Wall") Debug.Log("leave trigger");
    // }

    IEnumerator ResetColision()
    {
        yield return new WaitForEndOfFrame();
        isColiding = false;
    }

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if(other.gameObject.tag == "Bullet")
    //     {
    //         currentLife -= GameManager.Instance.GetDamage();
    //         other.gameObject.SetActive(false);
    //         Debug.Log(currentLife);
    //         lifeCount.text = currentLife.ToString();
    //     }
    // }
}
