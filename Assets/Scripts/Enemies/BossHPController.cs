using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPController : MonoBehaviour
{
    public float EnemyMaxHealth;
    private float EnemyHealth;
    public Slider barra_vida;
    public GameObject gc;

    void Start()
    {
        EnemyHealth = EnemyMaxHealth;
    }

    private void Update()
    {
        if (EnemyHealth <= 0)
        {
            gc.GetComponent<EndController>().flag = true;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("bala"))
        {
            EnemyHealth--;
            barra_vida.value = EnemyHealth;
            Destroy(collision.gameObject);
            //Debug.Log(EnemyHealth);
        }
    }
}
