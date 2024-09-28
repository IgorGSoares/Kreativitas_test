using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Block : MonoBehaviour
{
    [SerializeField] int maxLife;
    [SerializeField] TextMeshProUGUI lifeCount;

    public int MaxLife { get { return maxLife; } set { maxLife = value; } }

    private int currentLife;

    private bool isColiding = false;

    void Start()
    {
        currentLife = maxLife;
        lifeCount.text = currentLife.ToString();
    }

    void Update()
    {
        if (currentLife <= 0) gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(isColiding) return;

        if(other.gameObject.tag == "Bullet")
        {
            isColiding = true;
            currentLife -= GameManager.Instance.GetDamage();
            other.gameObject.SetActive(false);
            Debug.Log(currentLife);
            lifeCount.text = currentLife.ToString();
            StartCoroutine(ResetColision());
        }
    }

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
