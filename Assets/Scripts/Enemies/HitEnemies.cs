using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemies : MonoBehaviour
{
    public float EnemyMaxHealth;
    public float EnemyHealth;
    public AudioSource RobotDeathSoundEffect;


    void Start()
    {
        EnemyHealth = EnemyMaxHealth;

    }

    private void Update()
    {
        
        if (EnemyHealth <= 0)
        {
            
            if (gameObject.tag.Equals("enemy") || gameObject.tag.Equals("EnemigoA"))
            {
                RobotDeathSoundEffect.Play();
                Destroy(gameObject);
            }
            
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("bala")){
            EnemyHealth-=collision.gameObject.GetComponent<BulletController>().daño;
            Destroy(collision.gameObject);
            //Debug.Log(EnemyHealth);
        }
    }
}



