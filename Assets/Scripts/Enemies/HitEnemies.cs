using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemies : MonoBehaviour
{
    public float EnemyMaxHealth;
    private float EnemyHealth;



    void Start()
    {
        EnemyHealth = EnemyMaxHealth;

    }

    private void Update()
    {
        
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("bala")){
            EnemyHealth--;
            Destroy(collision.gameObject);
            Debug.Log(EnemyHealth);
        }
    }
}



