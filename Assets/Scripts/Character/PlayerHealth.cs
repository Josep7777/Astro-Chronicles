using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerMaxHealth;
    private int playerHealth;
    private bool patata = false;
    public float tiempo_inmortal = 1f;

    public PlayerHealthbar healthBar;



    void Start()
    {
        playerHealth = playerMaxHealth;

    }

    private void Update()
    {
        Debug.Log(tiempo_inmortal);
        tiempo_inmortal -= Time.deltaTime;
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("enemy") && tiempo_inmortal <= 0)
        {
            playerHealth = playerHealth - 1;
            healthBar.SetHealth(playerHealth);
            tiempo_inmortal = 1f;
            Debug.Log(patata);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("enemybullet") && tiempo_inmortal <= 0)
        {
            playerHealth = playerHealth - 1;
            healthBar.SetHealth(playerHealth);
            tiempo_inmortal = 1f;
            patata = true;
        }

    }

}
